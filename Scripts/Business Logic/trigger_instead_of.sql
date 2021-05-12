create trigger trg_delete_volumes_instead_of_book
on Book instead of delete
as begin
    merge Volume
    using (select * from deleted) as books
    on volume.book_id = books.id
    when matched then delete; 
    print 'Deleted volumes instead of book.'
end;

drop trigger trg_delete_volumes_instead_of_book;