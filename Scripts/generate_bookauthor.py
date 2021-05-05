import random

random.seed()
f = open("populate_bookauthor.sql", "w")

bookTotal = 100
authorTotal = 100

for i in range(bookTotal):
    author = random.randint(1, authorTotal)
    f.write(f'insert into BookAuthor (book_id, author_id) values ({i}, {author});\n')
            
f.close()