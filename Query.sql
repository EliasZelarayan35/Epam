SELECT *
FROM StudyGroups
WHERE EXISTS (
    SELECT 1
    FROM Users
    WHERE StudyGroups.StudyGroupId = Users.StudyGroupId
    AND LEFT(Users.Name, 1) = 'M'
)
ORDER BY CreateDate;