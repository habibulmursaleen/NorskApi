MERGE INTO Subjunctions AS target
USING (VALUES 
    (NEWID(), 'Label1', 'TIME', GETDATE(), GETDATE()),
    (NEWID(), 'Label2', 'ARSAK', GETDATE(), GETDATE()),
    (NEWID(), 'Label3', 'BETINGELSE', GETDATE(), GETDATE()),
    (NEWID(), 'Label4', 'MOTSETNING', GETDATE(), GETDATE()),
    (NEWID(), 'Label5', 'HENSLIKT', GETDATE(), GETDATE())
) AS source (Id, Label, SubjunctionType, CreatedDateTime, UpdatedDateTime)
ON target.Id = source.Id
WHEN MATCHED THEN
    UPDATE SET 
        target.Label = source.Label,
        target.SubjunctionType = source.SubjunctionType,
        target.CreatedDateTime = source.CreatedDateTime,
        target.UpdatedDateTime = source.UpdatedDateTime
WHEN NOT MATCHED THEN
    INSERT (Id, Label, SubjunctionType, CreatedDateTime, UpdatedDateTime)
    VALUES (source.Id, source.Label, source.SubjunctionType, source.CreatedDateTime, source.UpdatedDateTime);
