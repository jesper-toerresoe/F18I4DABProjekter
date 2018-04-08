BEGIN TRAN  
UPDATE IsolationTests SET Col1 = 2323  
--Simulate having some intensive processing here with a wait
WAITFOR DELAY '00:00:10'  
ROLLBACK 