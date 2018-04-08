--Det er session 2
ALTER DATABASE [I4DABLockTest] --kør dette statement
SET ALLOW_SNAPSHOT_ISOLATION ON -- en gang 
ALTER DATABASE [I4DABLockTest]
SET ALLOW_SNAPSHOT_ISOLATION OFF 
--vælg på skift et af det tre Levels herunder både for denne session og den anden session
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE   
SET TRANSACTION ISOLATION LEVEL SNAPSHOT
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
-- Brug evt DBCC userpotions til at checke gældende Level
-- Dette er session "Nummer to" start med --2 statement så --3 og i den anden session --4 
-- og så fremdeles. Bemærk hvad der sker
BEGIN TRAN  --2
SELECT * FROM IsolationTests  --3
--WAITFOR DELAY '00:00:10'  
--SELECT * FROM IsolationTests
--UPDATE IsolationTests (Col1,Col2,Col3) VALUES(1,2,3) WHERE Id=
UPDATE       IsolationTests SET Col1 = 487, Col2 = 587, Col3 = 687 WHERE Id=8 --6
UPDATE       IsolationTests SET Col1 = 374, Col2 = 37, Col3 = 376 WHERE Id=14 --8
--ROLLBACK
COMMIT --9

SELECT * FROM IsolationTests
DBCC useroptions
SELECT snapshot_isolation_state_desc from sys.databases 
where name='I4DABLockTest'
SELECT * from sys.databases 
where name='I4DABLockTest' FOR JSON AUTO
