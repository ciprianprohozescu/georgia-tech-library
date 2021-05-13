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

delete from Book
where id = 1;

select * from Volume
where book_id = 1;

select * from Book
where id = 1;

select Book.id, Book.title from Book
left outer join Loan on Loan.book_id = Book.id
where Loan.book_id is null;

delete from Loan
where book_id = 1;