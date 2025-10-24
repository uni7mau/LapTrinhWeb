create table NdtCatalog (
hvtId INT IDENTITY(1, 1) PRIMARY KEY,
hvtCateName NVARCHAR(100),
hvtCatePrice FLOAT CHECK (hvtCatePrice BETWEEN 100 AND 5000),
hvtCateQty INT,
hvtPicture NVARCHAR(200),
hvtCateActive BIT);

INSERT INTO NguyenDucThachCatalog (hvtCateName,hvtCatePrice,hvtCateQty,hvtPicture,hvtCateActive)
VALUES 
(N'Ban phim co Akko', 1500, 3, 'keyboard.jpg', 1),
(N'Chuot logitech G Pro', 2500, 2, 'mouse.jpg', 1),
(N'Nguyen Duc Thach - Sinh vien 231230898', 3000, 1, 'self.jpg', 0)