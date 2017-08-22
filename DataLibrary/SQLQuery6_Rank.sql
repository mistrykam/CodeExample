select 
CustomerId, 
Count(*) order_count, 
row_number() over (order by count(*)) as [Row_Number],
rank() over (order by count(*)) as [Rank],
dense_rank() over (order by count(*)) as [Dense_Rank] 

from orders
group by CustomerId
order by count(*) desc 

