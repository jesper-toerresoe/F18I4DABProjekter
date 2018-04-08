/****** Session 2  ******/
BEGIN TRANSACTION ;
BEGIN TRAN
commit transaction;
ROLLBACK  TRANSACTION;
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE; /*Pessimistic locking*/ 
SET TRANSACTION ISOLATION LEVEL SNAPSHOT; /* Optimistic Locking*/
SET TRANSACTION ISOLATION LEVEL READ COMMITTED; /* Serialization Level below the to former levels*/
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;/* Serialization Level below the Read Commited*/
SET IMPLICIT_TRANSACTIONS OFF  /*Ends Auto Commit*/
SET IMPLICIT_TRANSACTIONS ON /*Starts Auto Commit*/
ALTER DATABASE [I4DABLockTest]
SET ALLOW_SNAPSHOT_ISOLATION ON 
ALTER DATABASE [I4DABLockTest]
SET ALLOW_SNAPSHOT_ISOLATION OFF

DBCC useroptions
SET READ_COMMITTED_SNAPSHOT ON


SELECT     EquipmentID, EE_Type, EE_Level, Description, ContainedIn
FROM         EquipElement ;
SELECT     EquipmentID, EE_Type, EE_Level, Description, ContainedIn
FROM         EquipElement WHERE Description = 'Hav H1v H7v';
SELECT     EquipmentID, EE_Type, EE_Level, Description, ContainedIn
FROM         EquipElement WHERE Description = 'Hav H1v H5v';


UPDATE EquipElement set Description = 'Hav H1v H7v' where Description = 'Hav H1v H5v' ;
UPDATE EquipElement set Description = 'Hav H1v H5v' where Description = 'Hav H1v H7v' ;

UPDATE EquipElement set Description = 'Vindmøllesystem klasse' where Description = 'Vindmøllesystem class1' ;
UPDATE EquipElement set Description = 'Vindmøllesystem class1' where Description = 'Vindmøllesystem klasse' ;



SELECT     EquipmentID, EE_Type, EE_Level, Description, ContainedIn
FROM         EquipElement;




--Vær forsigtig med at bruges LOCK options på enkelte statements bruges TRANSACTION LEVEL i stedet

SELECT     EquipmentID, EE_Type, EE_Level, Description, ContainedIn
FROM         EquipElement WITH (ROWLOCK);
SELECT     EquipmentID, EE_Type, EE_Level, Description, ContainedIn
FROM         EquipElement WITH (NOLOCK);
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
    { READ COMMITTED 
        | READ UNCOMMITTED 
        | REPEATABLE READ 
        | SERIALIZABLE 
    } 
    
    
--Vær forsigtig med at bruges LOCK options på enkelte statements bruges TRANSACTION LEVEL i stedet
    
    
UPDATE EquipElement WITH (ROWLOCK)set Description = 'Hav H1v H7v' where Description = 'Hav H1v H5v' ;
UPDATE EquipElement WITH (ROWLOCK)set Description = 'Hav H1v H7v' where Description = 'Hav H1v H5v' ;



UPDATE EquipElement WITH (ROWLOCK)set Description = 'Hav H1v H7v' where Description = 'Hav H1v H5v' ;
UPDATE EquipElement WITH (ROWLOCK)set Description = 'Hav H1v H5v' where Description = 'Hav H1v H7v' ;

UPDATE EquipElement WITH (ROWLOCK)set Description = 'Vindmøllesystem klasse' where Description = 'Vindmøllesystem class1' ;
UPDATE EquipElement WITH (ROWLOCK)set Description = 'Vindmøllesystem class1' where Description = 'Vindmøllesystem klasse' ;

SELECT CASE transaction_isolation_level 
WHEN 0 THEN 'Unspecified' 
WHEN 1 THEN 'ReadUncommitted' 
WHEN 2 THEN 'ReadCommitted' 
WHEN 3 THEN 'Repeatable' 
WHEN 4 THEN 'Serializable' 
WHEN 5 THEN 'Snapshot' END AS TRANSACTION_ISOLATION_LEVEL 
FROM sys.dm_exec_sessions 
where session_id = @@SPID

DBCC useroptions