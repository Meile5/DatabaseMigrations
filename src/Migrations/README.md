1. Books need authors  

An author table was added, as well as an authorBook table. We chose to add the authorBook 
table in order to allow a many-to-many relationship. In addition, we decided not to make it 
required that a book has an author, due to the possibility of a book not having one.

2. Email addresses must be unique, and the member profile is expanding

For this requirement we made a decision to create new tables for member and loan. This was necessary 
because it was not possible to add a non-null phone number column and populate it for existing members. 
Moreover, duplicate emails also caused an issue, as they could not be made unique on the existing table. 
Therefore, the best option was to leave the old tables and their data intact, create new ones with the correct 
implementation, and migrate existing member data into the new tables while keeping the old ones for safety.

3. Loans need a status, and the existing client cannot be updated yet

This case required us to add a status column without disrupting the existing data. Therefore, we allowed the status 
to be null for the next two sprints while everything is getting resolved and only then add not null check. 
This solution allows the front end to use returnDate like it was before while the new implementation is on the way.

4. Books can be retired from the catalogue

After reviewing the SQL submitted by the developer, we have made a decision to partially agree. This decision was made due 
to the fact that adding a flag to a book is valid and helps preserve the actual book in relation to loan history. However, 
the issue with the submission was related to the WHERE clause. For example, the SQL provided works well when retrieving books 
that are not deleted, but is misleading when books are retrieved through loans. When retrieving books via loans, the WHERE 
clause should not exclude deleted books, as loan history should show all books regardless of their status.

5. The ISBN column is wrong and used everywhere

In this case, the corrupted data cannot be used. Thus, we have made a decision make the ISBN column null and add a new ISBN 
column where would need to fix all the corrupted data. This allows us to make a new implementation without disrupting and removing 
old data. 

