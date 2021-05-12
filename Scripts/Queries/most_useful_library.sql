select name, count(Volume.id) as acquired_volumes from Library
left join Volume on Library.id = source_library_id
group by Library.id, Library.name
order by acquired_volumes desc;