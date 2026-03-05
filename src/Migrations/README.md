# 1. Books need authors

## Type of change:
Additive (non breaking)

## APIs: 
Added author information in the GET request for Books

## Deployment notes:
Since the migrations only add tables and doesnt change existing ones, it can be applied before redeploying the app without breaking functionality. The existing app can function fine with the new schema.

## Decisions:
An author table was added, as well as an authorBook table. We chose to add the BookAuthor 
table in order to allow a many-to-many relationship. In addition, we decided not to make it 
required that a book has an author, due to the possibility of a book not having one.

# 2. Email addresses must be unique, and the member profile is expanding

## Type of change:
Additive(non-breaking?), requires coordination

## APIs: 
We decided to make a new API for the new members table, to not break existing functionality with the current deployment. 
When a user logs in the front-end would check if the user exists in the new table, and if not, it will check the old table (using the old API).

## Deployment notes:  
This migration is considerate of the existing deployment and thus can be applied before redeploying, as none of the old tables will be changed. 
There may need to be some coordination with the frontend team on implementing the new functionality

## Decisions:
For this requirement we made a decision to create new tables for member and loan. This was necessary 
because it was not possible to add a non-null phone number column and populate it for new members. 
Moreover, duplicate emails also caused an issue, as they could not be made unique on the existing table. 
Therefore, the best option was to leave the old tables and their data intact, create new ones with the correct 
implementation, and migrate the existing member data (that can be migrated) into the new tables while keeping the old ones for safety. 
Users whose data could not be migrated will be prompted to change their email.

# 3. Loans need a status, and the existing client cannot be updated yet

## Type of change:
Additive(non-breaking), requires coordination

## APIs: 
A second version of the loan endpoint was made so that existing functionality could be supported for the 2 weeks that the frontend developers are unavailable.

## Deployment notes: 
This migration is considerate of the existing deployment and thus can be applied before redeploying, as none of the old tables will be changed. 
There may need to be some coordination with the frontend team on implementing the new functionality

## Decisions:
This case required us to add a status column without disrupting the existing data. Therefore, we allowed the status 
to be null for the next two sprints while everything is getting resolved and only then add not null check. 
This solution allows the front end to use returnDate like it was before while the new implementation is on the way.

# 4. Books can be retired from the catalogue

## Type of change:
Additive (non-breaking)

## APIs:
Existing endpoints updated to exclude books that are marked as isDeleted. Loan endpoint must still return books even if they are retired/deleted, so functionality was left the same.

## Deployment notes:
This migration has to be applied before deployment since the code is checking for the new isDeleted column. isDeleted is set to false by default so existing data should be fine.

## Decisions:
After reviewing the SQL submitted by the developer, we have made a decision to partially agree. This decision was made due 
to the fact that adding a flag to a book is valid and helps preserve the actual book in relation to loan history. However, 
the issue with the submission was related to the WHERE clause. For example, the SQL provided works well when retrieving books 
that are not deleted, but is misleading when books are retrieved through loans. When retrieving books via loans, the WHERE 
clause should not exclude deleted books, as loan history should show all books regardless of their status.


# 5. The ISBN column is wrong and used everywhere

## Type of change:
Additive (potentially breaking, due to corrupted data?), requires coordination

## APIs:
Existing endpoints now use the new ISBN column, however this column was left nullable (for the sake of existing data) which means that there's a chance it may return null and break functionality if not all data is migrated to the new column. A new ISBN column should be used for the corrected implementation, while the old column remains for backwards compatibility during transition.

## Deployment notes:
Apply the migration before redeploying so both the old and new ISBN columns exist in the schema. Then the backend would be updated to use the new ISBN column. This has to be coordinated with the frontend since the frontend will need to send strings instead of integers when adding a new book via POST request. Data correction/backfill can be done after deployment without deleting old data.

## Decisions:
In this case, the corrupted data cannot be used. Thus, we have made a decision to keep the ISBN column the same and add a new ISBNNew 
column where we would need to fix all the corrupted data. This allows us to make a new implementation without disrupting and removing 
old data.
