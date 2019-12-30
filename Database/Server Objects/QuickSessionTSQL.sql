CREATE EVENT SESSION [QuickSessionTSQL] ON SERVER 
ADD EVENT [sqlserver].[existing_connection]
    (
    ACTION ([package0].[event_sequence],
            [sqlserver].[session_id],
            [sqlserver].[client_hostname])
    ), 
ADD EVENT [sqlserver].[login]
    (
    SET collect_options_text = 1
    ACTION ([package0].[event_sequence],
            [sqlserver].[session_id],
            [sqlserver].[client_hostname])
    ), 
ADD EVENT [sqlserver].[logout]
    (
    ACTION ([package0].[event_sequence],
            [sqlserver].[session_id])
    ), 
ADD EVENT [sqlserver].[rpc_starting]
    (
    ACTION ([package0].[event_sequence],
            [sqlserver].[session_id],
            [sqlserver].[database_name])
    WHERE ([package0].[equal_boolean]([sqlserver].[is_system],(0)))
    ), 
ADD EVENT [sqlserver].[sql_batch_starting]
    (
    ACTION ([package0].[event_sequence],
            [sqlserver].[session_id],
            [sqlserver].[database_name])
    WHERE ([package0].[equal_boolean]([sqlserver].[is_system],(0)))
    )
WITH  (
        MAX_MEMORY = 16 MB,
        EVENT_RETENTION_MODE = ALLOW_SINGLE_EVENT_LOSS,
        MAX_DISPATCH_LATENCY = 5 SECONDS,
        MEMORY_PARTITION_MODE = PER_CPU,
        TRACK_CAUSALITY = ON,
        STARTUP_STATE = OFF
      );

