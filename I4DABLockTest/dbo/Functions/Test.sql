CREATE FUNCTION [dbo].[Test](@Number1 Decimal(6,2),
			 @Number2 Decimal(6,2))
RETURNS Decimal(6,2)
BEGIN
    DECLARE @Result Decimal(6,2)
    SET @Result = @Number1 + @Number2
    RETURN @Result
END;



