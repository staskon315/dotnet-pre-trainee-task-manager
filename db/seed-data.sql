USE TaskManagementDb;
INSERT INTO Tasks (Title, Description, IsCompleted)
VALUES 
    ('Buy groceries', 'Milk, bread, eggs, and some cheese', 0),
    ('Do homework', 'Finish the Dapper and SQL module',0),
    ('Call mom', NULL, 1),
    ('Make a doctor''s appointment', N'Dentist, preferably in the morning', 0),
    ('Walk the dog', 'Buy dog food on the way', 1),
    ('Read an article', 'About design patterns', 0);