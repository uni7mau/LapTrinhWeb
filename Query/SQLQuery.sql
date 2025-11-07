CREATE TABLE ndtCatalog (
    ndtId INT IDENTITY(1,1) PRIMARY KEY,
    ndtCateName NVARCHAR(100),
    ndtCatePrice INT,
    ndtCateQty INT,
    ndtPicture NVARCHAR(255),
    ndtCateActive BIT
);

INSERT INTO HvtCatalog (hvtCateName, hvtCatePrice, hvtCateQty, hvtPicture, hvtCateActive)
VALUES 
(N'Sản phẩm A', 200, 10, 'a.jpg', 1),
(N'Sản phẩm B', 500, 5, 'b.jpg', 0),
(N'Nguyen Duc Thach', 1200, 3, 'c.jpg', 1);