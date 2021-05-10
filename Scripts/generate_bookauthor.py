import random

random.seed()
f = open("populate_bookauthor.sql", "w")

bookTotal = 10000
authorTotal = 1000

for i in range(1, bookTotal + 1):
    author = random.randint(1, authorTotal)
    f.write(f'insert into BookAuthor (book_id, author_id) values ({i}, {author});\n')
            
f.close()