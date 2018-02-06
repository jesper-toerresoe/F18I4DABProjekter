--
-- Create Table    : 'Tilforordnede'   
-- TilfordnedeID   :  
-- TSKId           :  (references TurneringsSkakklub.TSKId)
--
CREATE TABLE Tilforordnede (
    TilfordnedeID  BIGINT IDENTITY(1,1) NOT NULL,
    TSKId          BIGINT NOT NULL,
CONSTRAINT pk_Tilforordnede PRIMARY KEY CLUSTERED (TilfordnedeID),
CONSTRAINT fk_Tilforordnede FOREIGN KEY (TSKId)
    REFERENCES TurneringsSkakklub (TSKId)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)