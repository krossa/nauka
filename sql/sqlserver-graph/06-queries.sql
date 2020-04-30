SELECT
    Locations.[Name],
    COUNT(*) AS [Number Of Ratings],
    AVG(Ratings.Score) AS [Average Rating]
FROM
    People, Ratings, Locations
WHERE 
    MATCH(People-(Ratings)->Locations)
GROUP BY 
    Locations.[Name]
ORDER BY 
    AVG(Ratings.Score) DESC,
    COUNT(*) DESC

-- ---------------------------------------------------------------------
-- ---------------------------------------------------------------------

SELECT
    Locations.[Name]
FROM 
    People AS People1, 
    Friends, 
    People AS People2, 
    Ratings, 
    Locations
WHERE 
    MATCH(People1-(Friends)->People2-(Ratings)->Locations)
    AND People1.FirstName = 'Alice'
    AND Ratings.Score = 5
GROUP BY
    Locations.[Name]

-- ---------------------------------------------------------------------
-- ---------------------------------------------------------------------

SELECT
    People2.FirstName
FROM
    People AS People1,
    Friends AS Friends1,
    People AS People2,
    Friends AS Friends2,
    People AS People3
WHERE 
    MATCH(People1-(Friends1)->People2-(Friends2)->People3)
    AND People1.FirstName = 'Alice'
    AND People3.FirstName = 'Alice'

-- ---------------------------------------------------------------------
-- ---------------------------------------------------------------------

SELECT
    People1.FirstName
FROM
    People AS People1,
    Friends AS Friends1,
    People AS People2,
    Friends AS Friends2,
    People AS People3
WHERE
    MATCH(People1-(Friends1)->People2-(Friends2)->People3)
    AND People1.Id = People3.Id
    AND People2.FirstName = 'Alice'