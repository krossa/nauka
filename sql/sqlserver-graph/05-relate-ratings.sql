INSERT INTO Ratings VALUES
    ((SELECT $node_id FROM People WHERE FirstName = 'Alice'),
     (SELECT $node_id FROM Locations WHERE [Name] = 'Tyne Bar'),
     5),
    ((SELECT $node_id FROM People WHERE FirstName = 'Bob'),
     (SELECT $node_id FROM Locations WHERE [Name] = 'Tyne Bar'),
     5),
    ((SELECT $node_id FROM People WHERE FirstName = 'Charlene'),
     (SELECT $node_id FROM Locations WHERE [Name] = 'Tyne Bar'),
     5)

INSERT INTO Ratings VALUES
    ((SELECT $node_id FROM People WHERE FirstName = 'Alice'),
     (SELECT $node_id FROM Locations WHERE [Name] = 'Gotham Town'),
     1),
    ((SELECT $node_id FROM People WHERE FirstName = 'Bob'),
     (SELECT $node_id FROM Locations WHERE [Name] = 'Gotham Town'),
     4),
    ((SELECT $node_id FROM People WHERE FirstName = 'Charlene'),
     (SELECT $node_id FROM Locations WHERE [Name] = 'Gotham Town'),
     1)

INSERT INTO Ratings VALUES
    ((SELECT $node_id FROM People WHERE FirstName = 'Charlene'),
     (SELECT $node_id FROM Locations WHERE [Name] = 'Tilleys'),
     5)