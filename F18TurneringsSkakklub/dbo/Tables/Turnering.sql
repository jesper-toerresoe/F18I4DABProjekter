--
-- Create Table    : 'Turnering'   
-- TurneridsId     :  
-- TSKId           :  (references TurneringsSkakklub.TSKId)
--
CREATE TABLE Turnering (
    TurneridsId    BIGINT IDENTITY(1,1) NOT NULL,
    TSKId          BIGINT NOT NULL,
CONSTRAINT pk_Turnering PRIMARY KEY CLUSTERED (TurneridsId),
CONSTRAINT fk_Turnering FOREIGN KEY (TSKId)
    REFERENCES TurneringsSkakklub (TSKId)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)