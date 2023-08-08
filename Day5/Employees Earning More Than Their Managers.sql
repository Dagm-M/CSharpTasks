# Write your MySQL query statement below
select a.name as "Employee" from Employee AS a, Employee AS b where  a.managerId = b.id and a.salary > b.salary;