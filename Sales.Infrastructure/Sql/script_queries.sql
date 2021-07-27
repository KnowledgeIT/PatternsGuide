SELECT		I.*
			, C.Imported
			, [IP].Price
			, T.[Value]
FROM		Item  I
INNER JOIN	ItemPrice [IP] 
ON			I.Id = [IP].ItemId
INNER JOIN	ItemCategory IC 
ON			I.Id = IC.ItemId
INNER JOIN	Category C 
ON			IC.CategoryId = C.Id
INNER JOIN	CategoryTax CT 
ON			C.Id = CT.CategoryId
INNER JOIN	TAX T
ON			CT.TaxId = T.Id
--WHERE		I.Id IN (7)
ORDER BY Name

SELECT	
			OI.OrderId
			, I.Name
			, OI.Quantity
			, OI.NetPrice
			, OI.TotalPrice
			, OI.TotalTaxes
FROM		[Order]		O
INNER JOIN	OrderItem	OI
ON			O.Id		=	OI.OrderId
INNER JOIN	Item		I
ON			OI.ItemId	=	I.Id

			