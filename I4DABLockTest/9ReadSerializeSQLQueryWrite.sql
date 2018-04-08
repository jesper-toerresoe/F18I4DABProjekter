--Det er session 1
INSERT INTO IsolationTests(Col1,Col2,Col3) VALUES (512,513,514) 
--vælg på skift et af det tre Levels herunder både for denne session og den anden session
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE  
SET TRANSACTION ISOLATION LEVEL SNAPSHOT
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
-- Brug evt DBCC userpotions til at checke gældende Level
-- Dette er session "Nummer et" start med --1 statement så --2  i den anden session  
-- og så fremdeles. Bemærk hvad der sker
BEGIN TRAN  -- 1
SELECT * FROM IsolationTests  --4
UPDATE       IsolationTests SET Col1 = 1434, Col2 = 11435, Col3 = 1436 WHERE Id=14 --5
UPDATE       IsolationTests SET Col1 = 3614, Col2 = 3615, Col3 = 3616 WHERE Id=8 --7
COMMIT --8
 
 SELECT snapshot_isolation_state_desc from sys.databases 
where name='I4DABLockTest'
-- Database Console Command  DBCC
DBCC useroptions