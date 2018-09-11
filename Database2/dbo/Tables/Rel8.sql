--
-- Create Table    : 'Rel8'   
-- IF5             :  (references Entity5.IF5)
-- ID6             :  (references Entity6.ID6)
-- TypeOfJoin      :  
--
CREATE TABLE Rel8 (
    IF5            BIGINT NOT NULL,
    ID6            BIGINT NOT NULL,
    TypeOfJoin     NVARCHAR NOT NULL,
CONSTRAINT pk_Rel8 PRIMARY KEY CLUSTERED (IF5,ID6),
CONSTRAINT fk_Rel8 FOREIGN KEY (IF5)
    REFERENCES Entity5 (IF5)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
CONSTRAINT fk_Rel82 FOREIGN KEY (ID6)
    REFERENCES Entity6 (ID6)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)