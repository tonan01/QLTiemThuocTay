---------------Thủ Tục--------------------

--Lấy thuốc(Bán thuốc)
go
create proc LayThuoc @mhd varchar(10),@nguoilap varchar(10),@mkh varchar(10),
@mlhd varchar(10),@img image,@mthuoc varchar(10),@sl int,@dg money
as
 begin
 --bán ct hd đã tồn tại
  if(select count(*) from CT_HOADON where maHD=@mhd and maThuoc=@mthuoc)>0 --chi tiết hóa đơn tồn tại
   begin
   -- cập nhật lại số lượng thấp hơn số lượng ban đầu
    if(select soLuong from CT_HOADON where maHD=@mhd and maThuoc=@mthuoc )>@sl
     begin
	  --cập nhật lại số lượng trong thuốc sl thuốc = sl thuốc + (sl thuốc dh - sl nhập vào)
	  update THUOC set soLuong=soLuong + (select soLuong-@sl from CT_HOADON where maHD=@mhd and maThuoc=@mthuoc)
	  where maThuoc=@mthuoc
	  --cập nhật lại số lượng
      update CT_HOADON set soLuong=@sl where maHD=@mhd and maThuoc=@mthuoc 
	 end
	-- cập nhật lại số lượng lơn hơn số lượng ban đầu
	if(select soLuong from CT_HOADON where maHD=@mhd and maThuoc=@mthuoc )<@sl
     begin
	  --cập nhật lại số lượng trong thuốc sl thuốc = sl thuốc - (sl nhập vào -sl thuốc dh)
	  update THUOC set soLuong=soLuong - (select @sl-soLuong from CT_HOADON where maHD=@mhd and maThuoc=@mthuoc)
	  where maThuoc=@mthuoc
	  --cập nhật lại số lượng
      update CT_HOADON set soLuong=@sl where maHD=@mhd and maThuoc=@mthuoc 
	 end
   end
  --bán đã có hd đơn nhưng chi tiết hóa đơn chưa có
  if((select count(*) from HOADON where maHD=@mhd)>0) and ((select count(*) from CT_HOADON where maHD=@mhd and maThuoc=@mthuoc)=0) --hóa đơn tồn tại và chi tiết ko có
   begin
    insert into CT_HOADON values(@mhd,@mthuoc,@sl,@dg)
	--cập nhật lại số lượng trong thuốc
	update THUOC set soLuong=soLuong-@sl where maThuoc=@mthuoc
   end
  --Tự do
  if((@mlhd='BTD') and ((select count(*) from HOADON where maHD=@mhd)=0))--tự do (và chưa có hóa đơn)
   begin
   --tạo hd mới
    insert into HOADON(ngayLap,nguoiLap,maKH,maLHD) values(GETDATE(),@nguoilap,@mkh,@mlhd)
	--lấy mã hóa đơn vừa mới tạo
	select @mhd=MAX(maHD) from HOADON
	--thêm vào ct hóa đơn
	insert into CT_HOADON values(@mhd,@mthuoc,@sl,@dg)
	--cập nhật lại số lượng trong thuốc
	update THUOC set soLuong=soLuong-@sl where maThuoc=@mthuoc
   end
  --Theo toa
  if((@mlhd='BTT') and ((select count(*) from HOADON where maHD=@mhd)=0))--Theo toa (và chưa có hóa đơn)
   begin
    --tạo hd mới
	insert into HOADON(ngayLap,nguoiLap,maKH,maLHD,hinhAnh) values(GETDATE(),@nguoilap,@mkh,@mlhd,@img)
    --lấy mã hóa đơn vừa mới tạo
	select @mhd=MAX(maHD) from HOADON
	--thêm vào ct hóa đơn
	insert into CT_HOADON values(@mhd,@mthuoc,@sl,@dg)
	--cập nhật lại số lượng trong thuốc
	update THUOC set soLuong=soLuong-@sl where maThuoc=@mthuoc
   end
 end

--chạy thử
exec LayThuoc '7','NV001','KH002','BTD','','T001',2,'1000' 
 
--tự động cập nhật tổng tiền
go
create trigger thanhTien_HD on CT_HOADON
for insert,update,delete
as
 begin
	update HOADON 
    set thanhTien=(select sum(soLuong*donGia) from 
    CT_HOADON where CT_HOADON.maHD=HOADON.maHD)
 end

--xuat hoa don
go
create proc inHD @mhd int
as
 begin
 select CT_HOADON.*,thanhTien from CT_HOADON,HOADON
where CT_HOADON.maHD=HOADON.maHD and CT_HOADON.maHD=@mhd
 end
exec inHD 40

--Xuất hóa đơn thanh toán
--xuat hoa don
go
create proc inHDThanhToan @mhd int,@tienKhach int,@tienDu int
as
 begin
 select CT_HOADON.*,thanhTien,@tienKhach as 'TienKhach',@tienDu as 'TienDu' from CT_HOADON,HOADON
 where CT_HOADON.maHD=HOADON.maHD and CT_HOADON.maHD=@mhd
 end
exec inHDThanhToan 39,1,0



