/****** Session 1  ******/
BEGIN TRANSACTION ;
commit transaction;
ROLLBACK  TRANSACTION;
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE; /*Pessimistic locking*/ 
SET TRANSACTION ISOLATION LEVEL SNAPSHOT; /* Optimistic Locking*/
SET TRANSACTION ISOLATION LEVEL READ COMMITTED; /* Serialization Level below the to former levels*/
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;/* Serialization Level below the Read Commited*/
SET IMPLICIT_TRANSACTIONS OFF  /*Ends Auto Commit*/
SET IMPLICIT_TRANSACTIONS ON /*Starts Auto Commmit*/
ALTER DATABASE [I4DABLockTest] 
SET ALLOW_SNAPSHOT_ISOLATION ON 
ALTER DATABASE [I4DABLockTest]
SET ALLOW_SNAPSHOT_ISOLATION OFF

/*
DBCC HELP ( 'dbcc_statement' | @dbcc_statement_var | '?' )  
[ WITH NO_INFOMSGS ]  

*/

/*
Msg 1205, Level 13, State 51, Line 17
Der opstod baglås mellem transaktionen (proces-id 61) på lås-ressourcer og en anden proces, og transaktionen er blevet valgt som offer for baglåsen. Kør transaktionen igen.
*/
SELECT     EquipmentID, EE_Type, EE_Level, Description, ContainedIn
FROM         EquipElement ;

SELECT     EquipmentID, EE_Type, EE_Level, Description, ContainedIn
FROM         EquipElement  WHERE Description= 'Hav H1v H7v';
SELECT     EquipmentID, EE_Type, EE_Level, Description, ContainedIn
FROM         EquipElement  WHERE Description= 'Hav H1v H5v';

UPDATE EquipElement set Description = 'Hav H1v H7v' where Description = 'Hav H1v H5v' ;
UPDATE EquipElement set Description = 'Hav H1v H5v' where Description = 'Hav H1v H7v' ;

UPDATE EquipElement set Description = 'Energi distributør class1' where Description = 'Energi distributør klasse' ;
UPDATE EquipElement set Description = 'Energi distributør klasse' where Description = 'Energi distributør class1' ;
UPDATE EquipElement set Description = 'Energi distributør klasse' where Description = 'Energi distributør class1' ;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
    { READ COMMITTED 
        | READ UNCOMMITTED 
        | REPEATABLE READ 
        | SERIALIZABLE 
    } 
    
    
--Vær forsigtig med at bruges LOCK options på enkelte statements bruges TRANSACTION LEVEL i stedet
SELECT     EquipmentID, EE_Type, EE_Level, Description, ContainedIn
FROM         EquipElement WITH (ROWLOCK);
SELECT     EquipmentID, EE_Type, EE_Level, Description, ContainedIn
FROM         EquipElement WITH (NOLOCK);

UPDATE EquipElement WITH (ROWLOCK)set Description = 'Hav H1v H5v' where Description = 'Hav H1v H7v' ;
UPDATE EquipElement WITH (ROWLOCK)set Description = 'Energi distributør class1' where Description = 'Energi distributør klasse' ;
UPDATE EquipElement WITH (ROWLOCK)set Description = 'Energi distributør klasse' where Description = 'Energi distributør class1' ;


SELECT CASE transaction_isolation_level 
WHEN 0 THEN 'Unspecified' 
WHEN 1 THEN 'ReadUncommitted' 
WHEN 2 THEN 'ReadCommitted' 
WHEN 3 THEN 'Repeatable' 
WHEN 4 THEN 'Serializable' 
WHEN 5 THEN 'Snapshot' END AS TRANSACTION_ISOLATION_LEVEL 
FROM sys.dm_exec_sessions 
where session_id = @@SPID