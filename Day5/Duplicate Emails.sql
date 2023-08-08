# Write your MySQL query statement below
select email from Person GROUP BY email Having Count(email) > 1;