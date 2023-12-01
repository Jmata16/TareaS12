USE [PracticaS12]
GO

CREATE TRIGGER ActualizarSaldoDespuesDeAbono
ON Abonos
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    
    UPDATE P
    SET P.Saldo = P.Saldo - I.Monto
    FROM Principal P
    INNER JOIN inserted I ON P.Id_Compra = I.Id_Compra;

    
    UPDATE P
    SET P.Estado = 'Pagado'
    FROM Principal P
    WHERE P.Saldo <= 0;
END;
