--1----------------------------------------------------------------------------
select model, speed, hd from pc where price<500
2----------------------------------------------------------------------------
select distinct maker 
from product  
where type = 'printer'
--3----------------------------------------------------------------------------
select distinct model, ram, screen from laptop where price>1000
--4----------------------------------------------------------------------------
select * from Printer where color like 'y'
--5----------------------------------------------------------------------------
select model, speed, hd from PC where cd in ('12x','24x') and price < 600
--6----------------------------------------------------------------------------
select distinct maker, speed
from product inner join laptop using(model)
where hd >= 10 and type like "Laptop"
--7----------------------------------------------------------------------------
select model, price
from laptop join product using(model)
where maker like 'B'
union 
select model, price
from pc join product using(model)
where maker like 'B'
union 
select model, price
from printer join product using(model)
where maker like 'B'
--8----------------------------------------------------------------------------
select distinct maker
from product
where type = 'pc' and 
maker not in 
(select maker 
from product 
where type = 'laptop') 
--9----------------------------------------------------------------------------
select distinct maker
from product join pc using(model)
where speed >= 450
--10---------------------------------------------------------------------------
select model, price
from printer
where price = (select max(price) from printer)
--11---------------------------------------------------------------------------
select avg(speed)
from pc
--12---------------------------------------------------------------------------
select avg(speed)
from Laptop
where price > 1000
--13---------------------------------------------------------------------------
select avg(speed) as Avg_speed
from pc join product using(model)
where maker like 'A'
--14---------------------------------------------------------------------------
select class, name, country
from ships join classes using(class)
where numGuns >=10
--15---------------------------------------------------------------------------
select hd
from pc
group by hd
having count(hd)>=2
--16---------------------------------------------------------------------------
select p.model, l.model, p.speed, p.ram
from pc p join 
(select speed, ram
from pc
group by speed, ram
having sum(speed)/speed = 2 and sum(ram)/ram = 2) as s 
on p.speed = s.speed and p.ram = s.ram join 
pc l on l.speed = s.speed and l.ram = s.ram and l.model < p.model
--17---------------------------------------------------------------------------
select distinct "laptop", model, speed
from laptop
where speed < (select min(speed) from pc)
--18---------------------------------------------------------------------------
select distinct maker, price
from product join printer using(model)
where color = 'y' 
and price = (select min(price) from printer where color = 'y')
--19---------------------------------------------------------------------------
select maker, avg(screen)
from product join laptop using(model)
where type like "Laptop"
group by maker
--20---------------------------------------------------------------------------
select maker, count(model)
from product
where type like 'PC' 
group by maker
having count(model)>=3
--21---------------------------------------------------------------------------
select maker, max(price)
from product join pc using(model)
where type like "pc"
group by maker
--22---------------------------------------------------------------------------
select speed, avg(price)
from PC
where speed > 600
group by speed
--23---------------------------------------------------------------------------
select maker 
from product join pc using(model)
where speed >=750
INTERSECT
select maker 
from product join Laptop using(model)
where speed >=750
--24---------------------------------------------------------------------------
select distinct model
from 
(select model, price from pc
union
select model, price from Laptop
union
select model, price from Printer) temp
where price = (select max(price) from 
(select model, price from pc
union
select model, price from Laptop
union
select model, price from Printer)temp) 
--25---------------------------------------------------------------------------
select distinct maker
from product
where type like 'Printer'and maker in 
(select maker 
from
(select maker, speed, model
from product join pc using(model)
where ram = (select min(ram) from pc)) as temp1
where speed = (select max(speed) from
(select maker, speed
from product join pc using(model)
where ram = (select min(ram) from pc)) as temp2))
--26---------------------------------------------------------------------------
select avg(price)
from 
(select price
from product join pc using(model)
where maker ='A'
union all
select price
from product join laptop using(model)
where maker ='A') temp
--27---------------------------------------------------------------------------
select product.maker, avg(pc.hd)
from pc, product where product.model = pc.model
and product.maker in ( select distinct maker
from product
where product.type = 'printer')
group by maker
--28---------------------------------------------------------------------------
select count(maker)
from
(select maker, count(model) as cm
from product
group by maker) temp
where cm = 1
--29---------------------------------------------------------------------------
select point, date, sum(inc), sum(out)
from
(select point, date, inc, null as out
from Income_o 
union all
select point, date, null as inc, out
from outcome_o) as temp
group by point, date
--30---------------------------------------------------------------------------
select point, date, sum(sum_out), SUM(sum_inc)
from
(select point, date, sum(inc) as sum_inc, null as sum_out 
from Income 
group by point, date
Union
select point, date, null as sum_inc, SUM(out) as sum_out 
from Outcome 
Group by point, date ) as t
group by point, date 
order by point
--31---------------------------------------------------------------------------
select class, country
from classes 
where bore>=16
--32---------------------------------------------------------------------------
Select country, cast(avg((power(bore,3)/2)) as numeric(6,2)) as weight
from (select country, classes.class, bore, name from classes left join ships on classes.class=ships.class
union all
select distinct country, class, bore, ship from classes t1 left join outcomes t2 on t1.class=t2.ship
where ship=class and ship not in (select name from ships) ) a
where name IS NOT NULL group by country
--33---------------------------------------------------------------------------
select ship
from outcomes
where battle like "north atlantic" and result like "sunk"
--34---------------------------------------------------------------------------
select name 
from ships join classes using(class) 
where displacement > 35000 and launched is not null and type= "bb"
and launched >=1922
--35---------------------------------------------------------------------------
select model, type
from product
where upper(model) not like '%[^a-z]%'
or model not like '%[^0-9]%'
--36---------------------------------------------------------------------------
select name
from ships join classes on ships.name=classes.class
union
select ship as name
from outcomes join classes on outcomes.ship=classes.class
--37---------------------------------------------------------------------------
select classes.class
from classes left join 
(select name, class
from ships
union
select ship as name, ship as class
from outcomes) temp ON classes.class = temp.class
group by class
having count(name) = 1
--38---------------------------------------------------------------------------
select distinct country
from classes
where type = "bb"
intersect
select distinct country
from classes
where type = "bc"
--39---------------------------------------------------------------------------
select ship
from
(select ship, date, result
from outcomes join battles on battles.name=outcomes.battle
where ship in
(select ship
from outcomes join battles on battles.name=outcomes.battle
where result ="damaged")) temp2
group by ship
having year(max(date)) not in
(select year(date)
from outcomes join battles on battles.name=outcomes.battle
where result like "damaged") 
--40---------------------------------------------------------------------------
select maker, type
from product
group by maker
having count(distinct type)=1 and count(model)>1
--41---------------------------------------------------------------------------
select maker, if(maker not in 
(select distinct maker
from product join laptop using(model)
where price is null) , max(m_price),null)
from
(select maker,  max(price) as m_price
from product join pc using(model)            
group by maker
union 
select maker,  max(price) as m_price
from product join laptop using(model)     
group by maker
union 
select maker,  max(price) as m_price
from product join printer using(model)
group by maker) as temp
group by maker
--42---------------------------------------------------------------------------
select distinct ship, battle
from outcomes join battles
where result like "sunk"
--43---------------------------------------------------------------------------
select name 
from battles
where year(date) not in 
(select distinct launched from ships where launched is not null) 
or date is null
--44----------------------------------------------------------------------------
select name 
from ships
where name like "R%"
union
select ship as name
from outcomes
where ship like "R%"
--45---------------------------------------------------------------------------
select name 
from ships
where name like "% % %"
union
select ship as name
from outcomes
where ship like "% % %"
--46---------------------------------------------------------------------------
select ship, displacement, numGuns
from Outcomes  left join ships on Outcomes.ship=ships.name
               left join classes on Outcomes.ship=Classes.class or Classes.class = ships.class
where Outcomes.battle like "Guadalcanal"
--47---------------------------------------------------------------------------

--48---------------------------------------------------------------------------
with t1 as (select * from Outcomes where result like "sunk"),
t2 as (select name, class from ships join classes using(class))
select distinct class
from t1 left join t2 on t1.ship=t2.name
where class is not null
union
select distinct class
from t1 left join classes on classes.class= t1.ship
where class is not null
--49---------------------------------------------------------------------------
select name 
from ships join classes using(class)
where bore =16
union
select ship
from outcomes join classes on outcomes.ship=classes.class
where bore =16
--50---------------------------------------------------------------------------
select distinct battles.name
from classes join ships on classes.class=ships.class
             join outcomes on outcomes.ship=ships.name
             join battles on outcomes.battle= Battles.name
where classes.class like "Kongo"
--51---------------------------------------------------------------------------
with allShips as
(select name, displacement, numGuns
from ships join classes using(class)
union
select ship, displacement, numGuns
from outcomes join classes on outcomes.ship=classes.class
union
select ship, displacement, numGuns
from ships join classes using(class) join outcomes on Outcomes.ship=ships.name or outcomes.ship=classes.class), 
disMaxGun as 
(select displacement, max(numGuns) as MG
from allShips  
group by displacement
having max(numGuns))
select name 
from allShips join disMaxGun on allShips.displacement=disMaxGun.displacement and allShips.numGuns=disMaxGun.MG
--52---------------------------------------------------------------------------
select name 
from ships join classes using(class)
where (country ="japan" or country is null)
and (type = "bb" or type is null) 
and (numGuns >= 9 or numGuns is null)
and (bore < 19 or bore is null)
and (displacement <= 65000 or displacement is null) 
--53---------------------------------------------------------------------------
select round(avg(numGuns),2)
from classes
where type = "bb"
--54---------------------------------------------------------------------------
with allShips as
(Select numguns, name
from classes left join ships using(class)
where type='bb' and name!='null' and class!='null'
union all
select distinct numguns, ship
from classes left join outcomes on classes.class=outcomes.ship
where ship not in (select name from ships) and class!='null' and type='bb') 
select round(avg(numGuns),2)
from allShips
--55---------------------------------------------------------------------------
select class, min(launched)
from ships right join classes using(class)
group by class
--56---------------------------------------------------------------------------
with t1 as
(select o.ship, sh.class
from outcomes o
left join ships sh on sh.name = o.ship
where o.result = 'sunk')
select classes.class, count(t1.ship)
from classes left join t1 on t1.class = classes.class or t1.ship = classes.class
group by classes.class
--57---------------------------------------------------------------------------
with shipsAndClass as
(select ship, if(class is null, ship, class) as class from
(select ship, if(Classes.class <> Ships.class, if(Classes.class is null, Ships.class, Classes.class), Ships.class) as class
from outcomes left join Classes on outcomes.ship = Classes.class
              left join ships on Outcomes.ship = Ships.name
where Classes.class is not null or Ships.class is not null
union
select name, class
from ships) temp),
needClass as (select class from shipsAndClass group by class having count(ship)>=3)

select class, count(ship)
from outcomes join shipsAndClass using(ship)
where result = "sunk" and class in (select class from shipsAndClass group by class having count(ship)>=3)
group by class 
--58---------------------------------------------------------------------------
with allProduct as (select maker,  count(model) as cp
from product
group by maker),
typeProduct as (select maker, type,  count(model) as ct
from product
group by maker, type),
alldata as 
(select maker, type, round(ct/cp*100,2) as prc
from allProduct join typeProduct using(maker)
union
select maker, type, round(0,2)
from (select distinct maker from product) t1, (select distinct type from product) t2)
select maker, type, sum(prc)
from alldata 
group by maker, type
--59---------------------------------------------------------------------------
select p1, sinc -
(case
when suot  is null then 0
else suot 
end)
from
(select point as p1, sum(inc) sinc from income_o
group by point) as t1
left join
(select point as p2, sum(out) as suot from outcome_o
group by point) as t2
on p1=p2
--60---------------------------------------------------------------------------
select p1, sinc -
(case
when suot  is null then 0
else suot 
end)
from
(select point as p1, sum(inc) sinc 
from income_o
where date < '2001-04-15'
group by point) as t1
left join
(select point as p2, sum(out) as suot 
from outcome_o
where date < '2001-04-15'
group by point) as t2
on p1=p2
--61---------------------------------------------------------------------------
select sum(m)
from
(select p1, sinc -
(case
when suot  is null then 0
else suot 
end) as m
from
(select point as p1, sum(inc) sinc from income_o
group by point) as t1
left join
(select point as p2, sum(out) as suot from outcome_o
group by point) as t2
on p1=p2)  as t
--62---------------------------------------------------------------------------
select sum(m)
from
(select p1, sinc -
(case
when suot  is null then 0
else suot 
end)as m
from
(select point as p1, sum(inc) sinc 
from income_o
where date < '2001-04-15'
group by point) as t1
left join
(select point as p2, sum(out) as suot 
from outcome_o
where date < '2001-04-15'
group by point) as t2
on p1=p2) as  tempt
--63---------------------------------------------------------------------------
select name from passenger
where id_psg in
(select id_psg 
from pass_in_trip
group by place, id_psg
having count(trip_no)>1)
--64---------------------------------------------------------------------------
with temp1 as
(select point, date, 'out' as operation , sum(out) as money_sum
from outcome
group by point, date),
temp2 as
(select point, date, 'inc' as operation , sum(inc) as money_sum
from income 
group by point, date)
select * from
temp1 
where not exists(select * from income where temp1.point = income.point and temp1.date= income.date)
union
select * from
temp2
where not exists(select * from outcome where temp2.point =outcome.point and temp2.date= outcome.date)
--65---------------------------------------------------------------------------
select row_number() over(order by maker) as num, case when t1=1 then maker else ''  end as maker, type
from 
(select row_number() over(partition by maker order by maker, ord) as t1, maker, type
from 
(select distinct maker, type, case when lower(type)='pc' then 1 when lower(type)='laptop' then 2 else 3 end as ord
from product) as t2) as t3
--66---------------------------------------------------------------------------
select dt, sum(qty) as qty from
(select date as dt, count(distinct trip.trip_no) as qty
from pass_in_trip join trip on pass_in_trip.trip_no=trip.trip_no
where town_from ='rostov' and date between '2003-04-01' and '2003-04-07'
group by date
union all
select '2003-04-01',0
union all
select '2003-04-02',0
union all
select '2003-04-03',0
union all
select '2003-04-04',0
union all
select '2003-04-05',0
union all
select '2003-04-06',0
union all
select '2003-04-07',0) as t1
group by dt
--67---------------------------------------------------------------------------
select count(*) as qty 
from (select count(*)as qty from trip group by town_from, town_to) as t1
where qty =(select max(nm) from (select count(*) as nm from trip group by town_from, town_to) as t2)
--68---------------------------------------------------------------------------
select count(*) as qty 
from 
(select count(*) as qty from trip 
group by case when town_from > town_to then town_from else town_to end, case when town_from < town_to then town_from else town_to end) as t1
where qty =(select max(nm) from 
(select count(*) as nm from trip 
group by case when town_from > town_to then town_from else town_to end, case when town_from < town_to then town_from else town_to end) as t2)
--69------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--70---------------------------------------------------------------------------
select distinct battle from 
(select battle, country from 
(select battle, country
from outcomes inner join classes on ship = class
where ship not in (select name from ships)
union all
select battle, country
from outcomes o
join ships s on o.ship = s.name
join classes c on s.class = c.class) as t1
group by battle, country
having count(*) >= 3) as t2
--71---------------------------------------------------------------------------
select distinct maker
from product join pc on product.model=pc.model
where maker not in 
(select distinct maker
from product left join pc on product.model=pc.model
where type = 'PC' and pc.model is null)
--72---------------------------------------------------------------------------
with bigTable as
(select passenger.name as pn, company.name as cn, trip.trip_no as tr  from company join trip on trip.id_comp=company.id_comp
join pass_in_trip on trip.trip_no=pass_in_trip.trip_no
join passenger on pass_in_trip.id_psg = passenger.id_psg),
toEndTable as
(select pn, count(tr) as ctr
from bigTable
group by pn
having count(distinct cn)=1)
select pn, ctr from toEndTable 
where ctr =(select max(ctr) from toEndTable)
--73---------------------------------------------------------------------------
with t1 as 
(select class, name from ships
union
select ship, ship from outcomes),
t2 as 
(select name, country, battle 
from classes left join t1 on classes.class=t1.class
join outcomes on t1.name=outcomes.ship)
select distinct classes.country, battles.name
from classes, battles where 
(select count(t2.country) from t2
where t2.country=classes.country and t2.battle=battles.name)=0
--74---------------------------------------------------------------------------
select country, class from classes
where country = if(exists (select class from classes where country = 'russia'), 'russia',country)
--75---------------------------------------------------------------------------
with bigTable as 
(select maker, laptop.price as lp, pc.price as pcp, printer.price as pp
from product left join pc on pc.model=product.model
left join laptop on product.model=laptop.model
left join printer on product.model=printer.model)
select maker, max(lp),max(pcp),max(pp)
from bigTable 
where lp is not null or pcp is not null or pp is not null
group by maker
--76---------------------------------------------------------------------------

--77---------------------------------------------------------------------------
with temp1 as (select distinct trip_no, date from pass_in_trip),
temp2 as
(select count(distinct plane) as dpc, date 
from temp1 join trip on temp1.trip_no=trip.trip_no
where town_from = 'Rostov'
group by date)
select * from temp2
where dpc = (select max(dpc) from temp2)
--78---------------------------------------------------------------------------
select name, dateadd(day, 1, eomonth(dateadd(month, -1, date))) firstd, eomonth(date) lastd from battles
--79---------------------------------------------------------------------------

--80---------------------------------------------------------------------------
select distinct maker 
from product
where maker not in
(select distinct maker 
from product left join pc on pc.model=product.model
where type='PC' and product.model is not null  and pc.model is null)
--81---------------------------------------------------------------------------
with outPerMonth as
(select  year(date) as yd, month(date) as md, sum(out) as so
from outcome
group by year(date), month(date))
select code, point, date, out
from outcome
where month(date) in 
(select md 
from outPerMonth  
where so = (select max(so) from outPerMonth))
and year(date) in
(select yd 
from outPerMonth  
where so = (select max(so) from outPerMonth))
--82---------------------------------------------------------------------------
with tmp as 
(select code, price, row_number() over(order by code ASC) as rownum from pc)
select code, (select avg(price) from tmp where rownum between a.rownum and a.rownum+5) as avg
from tmp a
where rownum <= (select max(rownum)-5 from tmp)
--83---------------------------------------------------------------------------
select name 
from
(select name, if(bore = 15,1,0) as b1, 
if(numGuns = 8,1,0) as b2, if(displacement = 32000,1,0) as b3, 
if(type = 'bb',1,0) as b4, if(launched = 1915,1,0) as b5, 
if(ships.class='Kongo',1,0) as b6, if(country='USA',1,0) as b7 
from ships join classes on ships.class=classes.class) as temp
where (b1+b2+b3+b4+b5+b6+b7)>=4
--84---------------------------------------------------------------------------
select company.name, 
SUM(if(day(date)<11, 1, 0)) as d1, 
SUM(if(day(date)<21 and day(date)>10, 1, 0)) as d2, SUM(if(day(date)>20, 1, 0)) as d3
from pass_in_trip join trip on pass_in_trip.trip_no=trip.trip_no 
join company on company.id_comp=trip.id_comp
where year(pass_in_trip.date)=2003 and month(pass_in_trip.date)=4
group by name
--85---------------------------------------------------------------------------
select maker 
from product 
group by maker 
having count(distinct type) = 1 and 
(min(type) = 'printer' or (min(type) = 'pc' and count(model) >= 3))
--86---------------------------------------------------------------------------
select maker,
case count(distinct type) 
when 2 then min(type) + '/' + max(type)
when 1 then max(type)
when 3 then 'laptop/pc/printer' end
from product
group by maker
--87---------------------------------------------------------------------------

--88---------------------------------------------------------------------------

--89---------------------------------------------------------------------------
with mm as
(select maker, count(model) as n
from product
group by maker)
select maker, count(model)
from product
group by maker
having count(model) = (select max(n) from mm) or count(model) = (select min(n) from mm)
--90---------------------------------------------------------------------------
with mint as
(select *
from product
order by model
limit 3),
maxt as
(select *
from product
order by model desc
limit 3)
select * from product
except
select * from mint
except
select * from maxt 
--91---------------------------------------------------------------------------
select cast(avg(num) as numeric(6,2))
from 
(select iif(sum(b_vol) is null, 0, cast(sum(b_vol) as numeric(6,2))) as num
from utq left join utb on utq.q_id=utb.b_q_id
group by q_id) as temp
--92---------------------------------------------------------------------------
with temp1 as
(select distinct b.b_q_id
from 
(select b_q_id
from utb
group by b_q_id
having sum(b_vol) = 765) as b
where b.b_q_id not in 
(select b_q_id
from utb
where b_v_id in (select b_v_id
from utb
group by b_v_id
having sum(b_vol) < 255)))
select q_name
from utq
where q_id in (select * from temp1)
--93---------------------------------------------------------------------------

--94---------------------------------------------------------------------------

--95---------------------------------------------------------------------------
select name,
count(distinct convert(char(24),date)+convert(char(4),trip.trip_no)),
count(distinct plane),
count(distinct id_psg),
count(*)
from pass_in_trip join trip on trip.trip_no=pass_in_trip.trip_no join company on company.id_comp= trip.id_comp
group by company.id_comp,name
--96---------------------------------------------------------------------------
select v_name
from 
(select utV.v_name, utV.v_id,
count(case when v_color = 'R' then 1 end) over(partition by v_id) as n1,
count(case when v_color = 'B' then 1 end) over(partition by b_q_id) as n2
from utV join utB on utV.v_id = utB.b_v_id) as t1
where n1 > 1 and n2 > 0
group by v_name
--97---------------------------------------------------------------------------

--98---------------------------------------------------------------------------

--99---------------------------------------------------------------------------

--100--------------------------------------------------------------------------
with temp1 as
(select distinct date, row_number() over(partition by date order by code asc) as n1 
from income
union 
select distinct date, row_number() over(partition by date order by code asc) 
from outcome),
temp2 as
(select date, point, inc, row_number() over(partition by date order by code asc) as n2 
from income),
temp3 as
(select date, point, out, row_number() over(partition by date order by code asc) as n3 
from outcome)
select distinct temp1.date , temp1.n1, temp2.point, temp2.inc, temp3.point, temp3.out
from  temp1
left join temp2 on temp2.date=temp1.date and temp2.n2=temp1.n1
left join  temp3 on temp3.date=temp1.date and temp3.n3=temp1.n1
--101--------------------------------------------------------------------------

--102--------------------------------------------------------------------------
with temp1 as
(select pass_in_trip.id_psg as n
from pass_in_trip join trip on pass_in_trip.trip_no=trip.trip_no
group by pass_in_trip.id_psg
having count(distinct case when trip.town_from<=trip.town_to then trip.town_from+trip.town_to else trip.town_to+trip.town_from end) = 1)
select passenger.name
from passenger
where passenger.id_psg in (select n from temp1)
--103--------------------------------------------------------------------------
select min(t1.trip_no), min(t2.trip_no), min(t3.trip_no), max(t1.trip_no), max(t2.trip_no), max(t3.trip_no)
From Trip t1, Trip t2, Trip t3
Where t1.trip_no < t2.trip_no and t2.trip_no < t3.trip_no
--104--------------------------------------------------------------------------
with guns as 
(select c1.class, c1.numguns, row_number() over(partition by c1.class order by c1.numguns) numb
from classes as c1, classes as c2
where c1.type = 'bc')
select distinct class, 'bc-'+cast(numb as varchar(2))
from guns
where numguns >= numb
--105--------------------------------------------------------------------------
select maker, model,
row_number() over(order by maker, model) as a,
dense_rank() over(order by maker) as b,
rank() over(order by maker) as c,
count(*) over(order by maker) as d
from product
--106--------------------------------------------------------------------------

--107--------------------------------------------------------------------------
select name, trip_no, date
from
(select row_number() over (order by pass_in_trip.date, trip.time_out, pass_in_trip.id_psg) as numb, company.name, trip.trip_no, pass_in_trip.date
from company join trip on trip.id_comp=company.id_comp join pass_in_trip on trip.trip_no=pass_in_trip.trip_no
where trip.town_from = 'rostov' and year(pass_in_trip.date) = 2003 and month(pass_in_trip.date) = 4) as t1
where numb = 5
--108--------------------------------------------------------------------------
select distinct	t1.b_vol as x, t2.b_vol as y, t3.b_vol as z
from utb t1 join utb t2 on t2.b_vol>t1.b_vol join utb t3 on t3.b_vol>t2.b_vol
where not (t3.b_vol>sqrt(square(t2.b_vol)+square(t1.b_vol)))
--109--------------------------------------------------------------------------
with temp1 as
(select b_q_id, v_color, sum(b_vol) as n
from utb join utv on utb.b_v_id = utv.v_id
group by b_q_id, v_color),
temp2 as
(select b_q_id, sum(n) as n
from temp1
group by b_q_id)
select q_name,(select count(*) as n from temp2 where n = 765),
(select count(*) as n from temp2 right join utq on utq.q_id=temp2.b_q_id where n is null)
from temp2 right join utq on utq.q_id=temp2.b_q_id
where n = 765 or n is null
--110--------------------------------------------------------------------------
with temp1 as
(select id_psg
from pass_in_trip join trip on pass_in_trip.trip_no=trip.trip_no 
where datename(weekday, date) = 'Saturday' and time_out>=time_in)
select name 
from passenger
where id_psg in (select id_psg from temp1)
--111--------------------------------------------------------------------------
with temp1 as
(select b_q_id, v_color, sum(b_vol) as n
from utb join utv on utb.b_v_id = utv.v_id
group by b_q_id, v_color
having sum(b_vol)<>255),
temp2 as
(select b_q_id, avg(n) as n
from temp1
group by b_q_id
having count(*)=3 and max(n)= avg(n) and min(n)= avg(n))
select q_name, n
from temp2 join utq on utq.q_id = temp2.b_q_id
--112--------------------------------------------------------------------------
with q as 
(select v_color, v_id, 
case 
when sum(b_vol) is null 
then 255 
else 255-sum(b_vol) 
end n
from utb right join utv on b_v_id = v_id 
group by v_color, v_id) 
select iif(count(*)=3, min(tempn ),0)
from 
(select sum(n)/255  as tempn from q  
group by v_color) as t1
--113--------------------------------------------------------------------------
with temp1 as
(select b_q_id, v_color, sum(b_vol) as n
from utb join utv on utb.b_v_id = utv.v_id
group by b_q_id, v_color),
temp2b as
(select 255 - sum(n) as n
from temp1
where v_color='B'
group by b_q_id),
temp3b as
(select count(distinct q_id) as cn
from utq
where q_id not in (select distinct b_q_id from temp1 where v_color='B')),
temp4b as
(select sum(n)+255*(select cn from temp3b) as n
from temp2b), 
temp2r as
(select 255 - sum(n) as n
from temp1
where v_color='R'
group by b_q_id),
temp3r as
(select count(distinct q_id) as cn
from utq
where q_id not in (select distinct b_q_id from temp1 where v_color='R')),
temp4r as
(select sum(n)+255*(select cn from temp3r) as n
from temp2r), 
temp2g as
(select 255 - sum(n) as n
from temp1
where v_color='G'
group by b_q_id),
temp3g as
(select count(distinct q_id) as cn
from utq
where q_id not in (select distinct b_q_id from temp1 where v_color='G')),
temp4g as
(select sum(n)+255*(select cn from temp3g) as n
from temp2g)
select temp4r.n, temp4g.n, temp4b.n 
from temp4r, temp4g, temp4b
--114--------------------------------------------------------------------------
with temp1 as
(select id_psg, place, count(*) as n
from pass_in_trip
group by id_psg, place),
temp2 as
(select distinct id_psg, n
from temp1
where n = (select max(n) from temp1))
select name, n
from temp2 join passenger on temp2.id_psg=passenger.id_psg
--115--------------------------------------------------------------------------

--116--------------------------------------------------------------------------
with temp1 as
(select b_datetime, iif(isnull(datediff(second, lag(b_datetime)over(order by b_datetime), b_datetime),0)<=1,0,1) as n
from utb),
temp2 as
(select b_datetime, sum(n) over(order by b_datetime rows unbounded preceding) as sm
from temp1)
select min(b_datetime) as date_begin, max(b_datetime) as date_finish
from
temp2 
group by sm
having datediff(second,min(b_datetime),max(b_datetime))> 0
--117--------------------------------------------------------------------------
with temp1 as
(select country, max(numguns)*5000 as m1, max(bore)*3000 as m2, max(displacement) as m3
from classes
group by country),
temp2 as
(select country, iif(m1>=m2 and m1>=m3,m1, iif(m2>=m1 and m2>=m3,m2,iif(m3>=m1 and m3>=m2,m3,m3))) as maxValue
from temp1)
select temp1.country, m1, 'numguns'
from temp1, temp2
where m1 = maxValue and temp1.country = temp2.country
union all
select temp1.country, m2, 'bore'
from temp1, temp2
where m2 = maxValue and temp1.country = temp2.country
union all
select temp1.country, m3, 'displacement'
from temp1, temp2
where m3 = maxValue and temp1.country = temp2.country
--118--------------------------------------------------------------------------

--119--------------------------------------------------------------------------
select cast(year(b_datetime) as varchar), sum(b_vol)
from utb
group by year(b_datetime)
having count(distinct b_datetime)>10
union all
select
concat(year(b_datetime),'-',iif(cast(month(b_datetime) as int)>9,'', '0'),month(b_datetime)), 
sum(b_vol)
from utb
group by year(b_datetime), month(b_datetime)
having count(distinct b_datetime)>10
union all
select 
concat(year(b_datetime),'-', iif(cast(month(b_datetime) as int)>9,'', '0'),month(b_datetime),'-', iif(cast(day(b_datetime) as int)>9,'','0'), day(b_datetime)), 
sum(b_vol)
from utb
group by year(b_datetime), month(b_datetime), day(b_datetime)
having count(distinct b_datetime)>10
--120--------------------------------------------------------------------------
with temp1 as
(select id_comp, 
convert(numeric(18,2), case 
when time_in > = time_out then datediff(minute, time_out, time_in)
else datediff(minute, time_out, dateadd(day, 1, time_in))
end) as mintr
from 
(select trip_no
from pass_in_trip
group by trip_no, [date]) as temp2 
join trip on temp2.trip_no = trip.trip_no)
select coalesce(company.name, 'total'), a, b, c, d
from 
(select id_comp ,
convert(numeric(18,2), avg(mintr)) as a,
convert(numeric(18,2), exp(avg(log(mintr))))  as b,
convert(numeric(18,2), sqrt(avg(mintr*mintr))) as c ,
convert(numeric(18,2), count(*)/sum(1/mintr)) as d
from temp1
group by id_comp with cube) as temp2 
left join company on temp2.id_comp =company.id_comp
--121--------------------------------------------------------------------------
with temp1 as 
(select name, launched, 
(select case 
when s.launched is null then max(date) 
else min(date) end
from Battles
where datepart(year,date) >= coalesce(s.launched,0)) as date
from Ships s)
select temp1.name, temp1.launched, Battles.name
from temp1 left join Battles on temp1.date=Battles.date
--122--------------------------------------------------------------------------
with temp1 as
(select id_psg, min(date) as mid, max(date) as mad
from pass_in_trip
group by id_psg),
temp2 as
(select  pass_in_trip.id_psg, town_from
from trip join pass_in_trip on trip.trip_no=pass_in_trip.trip_no
join temp1 on temp1.mid=pass_in_trip.date and temp1.id_psg=pass_in_trip.id_psg
group by pass_in_trip.id_psg, town_from),
temp3 as
(select  pass_in_trip.id_psg, town_to
from trip join pass_in_trip on trip.trip_no=pass_in_trip.trip_no
join temp1 on temp1.mad=pass_in_trip.date and temp1.id_psg=pass_in_trip.id_psg
group by pass_in_trip.id_psg, town_to),
temp4 as
(select temp2.id_psg, town_from, iif(town_to=town_from,1,0) as n
from temp2 join temp3 on temp2.id_psg = temp3.id_psg)
select name, min(town_from)
from temp4 join passenger on passenger.id_psg=temp4.id_psg
where n = 0 
group by name
--123--------------------------------------------------------------------------
with temp1 as
(select count(model) grp from product where type='printer'),
temp12 as
(select n-(temp1.grp*((n-1)/temp1.grp)) as num, model,type,2 pizda
from 
(select model, row_number() over(order by model) as n, type 
from product where type = 'pc') as t1 cross join temp1
union all
select row_number() over(order by model), model,type, 1 
from product where type='printer')
select row_number() over(order by num, pizda, model), model, type
from temp12 order by num, pizda, model
--124--------------------------------------------------------------------------

--125--------------------------------------------------------------------------
with tab as 
(select p.id_psg, p.name, pit.trip_no, pit.date, pit.place, row_number() over(partition by p.id_psg order by pit.date, t.time_out) num
from passenger p join pass_in_trip pit on pit.id_psg = p.id_psg join trip t on t.trip_no = pit.trip_no)
select t1.name
from tab t1 join tab t2 on t2.id_psg = t1.id_psg and t2.place = t1.place and t2.num = t1.num + 1
group by t1.id_psg, t1.name
--126--------------------------------------------------------------------------
with temp1 as
(select id_psg
from pass_in_trip
group by id_psg
having count(trip_no)= 
(select max(ctn) as n 
from (select id_psg, count(trip_no) as ctn
from pass_in_trip
group by id_psg) as t1)),
temp2 as
(select n, id_psg, name
from 
(select row_number() over(order by id_psg) as n, id_psg, name from passenger) as t1
where id_psg in (select id_psg from temp1))
select temp2.name, 
(select name from 
(select row_number() over(order by id_psg) as n, id_psg, name from passenger) as t2
where t2.n=
iif(temp2.n = 1, (select max(n) from (select row_number() over(order by id_psg) as n, id_psg, name from passenger) as t4), temp2.n-1)), 
(select name from 
(select row_number() over(order by id_psg) as n, id_psg, name from passenger) as t2
where t2.n = 
iif(temp2.n = (select max(n) from (select row_number() over(order by id_psg) as n, id_psg, name from passenger) as t4), 1, temp2.n+1))
from temp2
--127--------------------------------------------------------------------------
with mincd as
(select distinct maker
from pc join product on product.model=pc.model
where cast(replace(cd,'x','') as numeric(9,2)) = (select min(cast(replace(cd,'x','') as numeric(9,2))) from pc join product on product.model=pc.model)),
firstp as
(select min(price) as p1
from Laptop join product on product.model=Laptop.model
where maker in (select maker from mincd)),
minpr as
(select distinct maker 
from Printer join product on product.model=Printer.model
where price = (select min(price) from Printer join product on product.model=Printer.model)),
secondp as
(select max(price) as p2
from pc join product on product.model=pc.model
where maker in (select maker from minpr)),
maxm as
(select distinct maker 
from Laptop join product on product.model=Laptop.model
where ram = (select max(ram) from Laptop join product on product.model=Laptop.model)),
trip as
(select max(price) as p3
from Printer join product on product.model=Printer.model
where maker in (select maker from maxm))
select case
when p1 is not null and p2 is not null and p3 is not null then cast((p1+p2+p3)/3 as numeric(9,2))
when p1 is null and p2 is not null and p3 is not null then cast((p2+p3)/2 as numeric(9,2))
when p1 is not null and p2 is null and p3 is not null then cast((p1+p3)/2 as numeric(9,2))
when p1 is not null and p2 is not null and p3 is null then cast((p1+p2)/2 as numeric(9,2))
when p1 is null and p2 is null and p3 is not null then cast(p3 as numeric(9,2))
when p1 is not null and p2 is null and p3 is null then cast(p1 as numeric(9,2))
when p1 is null and p2 is not null and p3 is null then cast(p2 as numeric(9,2))
end
from firstp, secondp, trip
--128--------------------------------------------------------------------------
with temp1 as
(select point, date, sum(out) as su
from outcome
group by point, date),
temp2 as
(select  outcome_o.point, outcome_o.date, iif(su is null,0,su) as su, iif(out is null,0,out) as out
from outcome_o full join temp1 on outcome_o.date = temp1.date and outcome_o.point= temp1.point)
select temp2.point, temp2.date, iif(su=out,'both',iif(su<out,'once a day','more than once a day'))
from temp2
--129--------------------------------------------------------------------------
with temp1 as
(select n from 
(select row_number() over(order by b_datetime) as n from utb
union
select -(row_number() over(order by b_datetime)) as n from utb
union
select 0 from utb
except
select q_id from utq) as t1
where n>=(select min(q_id) from utq) and n<=(select max(q_id) from utq))
select iif(exists(select n from temp1), min(n),null), iif(exists(select n from temp1), max(n),null)  
from temp1
--130--------------------------------------------------------------------------
with allbat as
(select row_number() over(order by date, name) as n, name , date
from battles),
maxn as
(select max(n) as mn from allbat),
toppp as
(select top(iif((select max(n) as mn from allbat)%2=0,(select max(n) as mn from allbat)/2,((select max(n) as mn from allbat)/2)+1)) * from allbat)
select toppp.n, toppp.name, toppp.date, allbat.n, allbat.name, allbat.date
from allbat right join toppp on allbat.n = toppp.n + iif((select max(n) as mn from allbat)%2=0,(select max(n) as mn from allbat)/2,((select max(n) as mn from allbat)/2)+1)
--131--------------------------------------------------------------------------

--132--------------------------------------------------------------------------
with cte as 
(select trip_no,
cast(trip_no as integer) as num,
cast('' as varchar(max)) as str
from trip
union all
select trip_no, num / 2, concat(num % 2, str)
from cte
where num <> 0)
select trip_no, str trip_no_bit
from cte
where num = 0
--133--------------------------------------------------------------------------
with temp1 as
(select row_number() over(order by q_id) as n, q_id 
from utq),
tz as
(select row_number() over(order by q_id) as n, q_id
from temp1 
where (n%3)=0),
tx as
(select row_number() over(order by q_id) as n, q_id
from temp1 
where (n%3)=1),
ty as
(select row_number() over(order by q_id) as n, q_id
from temp1 
where (n%3)=2)
select tx.q_id, ty.q_id, tz.q_id
from tx left join ty on tx.n=ty.n left join tz on tx.n=tz.n
--134--------------------------------------------------------------------------

--135--------------------------------------------------------------------------
select max(B_DATETIME) 
from utb
group by YEAR(B_DATETIME), MONTH(B_DATETIME), DAY(B_DATETIME),DATEPART(  hour, B_DATETIME)
--136--------------------------------------------------------------------------
select name, patindex('%[^a-z]%',name) as n, substring(name, patindex('%[^a-z]%',name),1)
from ships
where name like '%[^a-z]%'
--137--------------------------------------------------------------------------
select type, price
from 
(select row_number() over(order by product.model) as n, product.type,
case product.type
when 'PC' then pc.price
when 'Laptop' then Laptop.price
when 'Printer' then Printer.price
end as price
from product left join pc on product.model=pc.model
left join Laptop on product.model=Laptop.model
left join Printer on product.model=Printer.model) as t1
where (n % 5) = 0
--138--------------------------------------------------------------------------
with passCount as
(select id_psg, count(distinct town) as cdt
from 
(select id_psg, town_from as town
from trip join pass_in_trip on trip.trip_no=pass_in_trip.trip_no
union
select id_psg, town_to
from trip join pass_in_trip on trip.trip_no=pass_in_trip.trip_no) as t1
group by id_psg),
needPassen as
(select id_psg
from passCount 
where cdt = (select max(cdt) from passCount))
select name 
from passenger
where id_psg in (select id_psg from needPassen)
--139--------------------------------------------------------------------------
with allCountry as
(select distinct country from classes),
battleCountry as
(select distinct country from 
(select class as name, country from classes
union
select name, country  
from ships join classes on classes.class=ships.class) as t1
where name in (select ship from outcomes))
select country from allCountry 
except
select country from battleCountry
--140--------------------------------------------------------------------------

--141--------------------------------------------------------------------------
with mad as
(select id_psg, max(date) as ma
from pass_in_trip
group by id_psg),
mid as
(select id_psg, min(date) as mi
from pass_in_trip
group by id_psg)
select name, 
case
when mi>'2003-4-30' then 0
when ma<'2003-4-1' then 0
when mi<'2003-4-1' and ma>'2003-4-30' then 30
when mi<'2003-4-1' and ma<='2003-4-30'and ma>='2003-4-1' then datediff(day,'2003-4-1',ma)+1
when mi>='2003-4-1' and mi<='2003-4-30' and ma>'2003-4-30' then datediff(day,mi,'2003-4-30')+1
when mi>='2003-4-1' and mi<='2003-4-30' and ma>='2003-4-1' and ma<='2003-4-30' then datediff(day,mi,ma)+1
end as cnt
from passenger join mad on passenger.id_psg=mad.id_psg
join mid on passenger.id_psg=mid.id_psg
--142--------------------------------------------------------------------------
select name 
from passenger join
(select passenger.id_psg as i
from passenger join pass_in_trip on passenger.id_psg=pass_in_trip.id_psg
join trip on trip.trip_no=pass_in_trip.trip_no
group by passenger.id_psg
having count(distinct plane)=1
intersect
select passenger.id_psg as i
from passenger join pass_in_trip on passenger.id_psg=pass_in_trip.id_psg
join trip on trip.trip_no=pass_in_trip.trip_no
group by town_to, passenger.id_psg
having count(trip.trip_no)>=2) as t1
on t1.i=passenger.id_psg
--143--------------------------------------------------------------------------
select name, format(date,'yyyy-MM-dd'),  
format(dateadd(dd,(datediff(dd,-53686,EOMONTH(date))/7)*7,-53686),'yyyy-MM-dd')
from battles
--144--------------------------------------------------------------------------
select distinct maker
from product join pc on product.model=pc.model
where price = (select max(price) from pc)
intersect
select distinct maker
from product join pc on product.model=pc.model
where price = (select min(price) from pc)
--145--------------------------------------------------------------------------

--146--------------------------------------------------------------------------
select chr, value
from
(select model, 
cast(speed as varchar(50)) as speed, 
cast(ram as varchar(50)) as ram,
cast(hd as varchar(50)) as hd, 
cast(cd as varchar(50)) as cd, 
cast(price as varchar(50)) as price 
from pc
where code = (select max(code) from pc)) as temp1
UNPIVOT (value for chr in(model, speed , ram, hd, cd, price)) temp2
--147--------------------------------------------------------------------------
with temp1 as
(select  maker, count(model) as cm
from product
group by maker)
select row_number() over(order by cm desc, product.maker, model ) as no, product.maker, model
from product join temp1  on temp1.maker=product.maker
--148--------------------------------------------------------------------------
select ship,
REPLACE(ship,SUBSTRING(ship, CHARINDEX(' ', ship)+1, CHARINDEX(' ', REPLACE(ship, left(ship, CHARINDEX(' ', ship)),'') ) - 1), left('************************',CHARINDEX(' ', REPLACE(ship, left(ship, CHARINDEX(' ', ship)),'') ) - 1)) as new_name
from outcomes
where ship like '% % %'
--149--------------------------------------------------------------------------
with bt as
(select b_v_id, min(b_datetime) as mbdt
from utb
group by b_v_id),
temp1 as
(select distinct utv.v_id
from utb join utv on utb.b_v_id=utv.v_id
where b_datetime = (select max(mbdt) from bt))
select v_name 
from utv
where v_id in (select * from temp1)
--150--------------------------------------------------------------------------
with temp1 as
(select point, min(date) as mi, max(date) as ma
from income
group by point)
select point,
(select max(date) from income where date<temp1.mi),
mi,ma,
(select min(date) from income where  date>temp1.ma)
from temp1


