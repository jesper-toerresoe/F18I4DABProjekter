DBCC useroptions  /* Database Console Command */
DBCC USEROPTIONS WITH NO_INFOMSGS
DBCC HELP ('?');  
GO  


SELECT CASE transaction_isolation_level 
WHEN 0 THEN 'Unspecified' 
WHEN 1 THEN 'ReadUncommitted' 
WHEN 2 THEN 'ReadCommitted' 
WHEN 3 THEN 'Repeatable' 
WHEN 4 THEN 'Serializable' 
WHEN 5 THEN 'Snapshot' END AS TRANSACTION_ISOLATION_LEVEL 
FROM sys.dm_exec_sessions 
where session_id = @@SPID

SELECT @@SPID

DBCC useroptions
SELECT snapshot_isolation_state_desc from sys.databases 
where name='I4DABLockTest'
SELECT * from sys.databases 
where name='I4DABLockTest' FOR JSON PATH
