create index ix_volume_id
on Loan (volume_id);

drop index Loan.ix_volume_id;

create index ix_member_id
on Loan (member_id);

drop index Loan.ix_member_id;

create index ix_loan_date
on Loan (loan_date);

drop index Loan.ix_loan_date;

create index ix_book_id
on Loan (book_id);

drop index Loan.ix_book_id;

create index ix_title
on Book (title);

drop index Book.ix_title;

create index ix_source_library_id
on Volume (source_library_id);

drop index ix_source_library_id;