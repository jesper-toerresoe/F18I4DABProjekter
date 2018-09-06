--
-- Create Table    : 'deltageri'   
-- TilfordnedeID   :  (references Tilforordnede.TilfordnedeID)
-- TurneridsId     :  (references Turnering.TurneridsId)
--
CREATE TABLE deltageri (
    TilfordnedeID  BIGINT NOT NULL,
    TurneridsId    BIGINT NOT NULL,
CONSTRAINT pk_deltageri PRIMARY KEY CLUSTERED (TilfordnedeID,TurneridsId),
CONSTRAINT fk_deltageri FOREIGN KEY (TilfordnedeID)
    REFERENCES Tilforordnede (TilfordnedeID)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
CONSTRAINT fk_deltageri2 FOREIGN KEY (TurneridsId)
    REFERENCES Turnering (TurneridsId)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)