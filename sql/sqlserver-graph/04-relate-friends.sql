INSERT INTO Friends VALUES
    ((SELECT $node_id FROM People WHERE FirstName = 'Alice'),
     (SELECT $node_id FROM People WHERE FirstName = 'Charlene'),
     GETDATE()),
    ((SELECT $node_id FROM People WHERE FirstName = 'Charlene'), --Charlene is also friends with Alice!
     (SELECT $node_id FROM People WHERE FirstName = 'Alice'),
     GETDATE()),
    ((SELECT $node_id FROM People WHERE FirstName = 'Alice'),
     (SELECT $node_id FROM People WHERE FirstName = 'Bob'),
     GETDATE()),
    ((SELECT $node_id FROM People WHERE FirstName = 'Charlene'),
     (SELECT $node_id FROM People WHERE FirstName = 'Doreen'),
     GETDATE())