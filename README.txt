As we want to perform a fast search of words by prefix in a long text or list, I started to lookup good prefix/keyword search algorithms. I found several including Boyer-Moore one. 

But I realised it was too complex for what we need and as loading time was not important but searching time, it make sense that instead of apply a search algorithm, we load the data first in an efficient structure. 

After I investigate I concluded that a TRIE or prefix tree (http://en.wikipedia.org/wiki/Trie) is the perfect structure for this Task as it require some time for Building the TRIE but is very fast searching. 

I found some existing TRIE implementations which I used (To not reinvent the wheel) and adapt to my own way so I can understand it better.

It can also be improved more if needed using a Radix/Patricia tree (http://en.wikipedia.org/wiki/Radix_tree) which is a compressed version of a normal TRIE which is faster and requires less memory/space. 
But I think it was overcomplicating this task. However is not difficult to add to the project if needed as is similar so I set a BaseNode class and an Interface ITrie if needed in future, so is extensible.


IMPORTANT THINGS TO KNOW ABOUT PROJECT:

- The way I am obtaining the next character could be improved, but did not have time to take a look into that.
- The class T I used to create the TRIE<T> is WordPosition. It could be improved as is tied to working with a file and is not relevant in all the cases, but it was just created for this particular
application, if I need to do it generic or for a real app I would have use a much better class.

- DEMO APP assume that you will load the list of stations in a simple text file (.txt)
- DEMO APP Assume that file(s) contains ONE (1) station per line, this is because there are stations with several words and you have to agree on a way to know when a station name finishes 
(I could have done it better like surrounding station names with single quotes and then separating them by space or comma, but again I think it was overcomplicating things for this task)
- DEMO APP Load all stations in file(s) into a TRIE structure when loading (loading could be slow although I tested with a big file with more than 5000 stations and it just took seconds)
- DEMO APP will search for words when you type 3 or more characters in the search bar. It will lookup in the TRIE structure and return the matching stations, next character, line number in file and filename


Notes about tests: 

- Due to investigation part and reuse/modify TRIE implementations and due to it was just a simple task, I did not apply TDD this time, but instead I added the unit tests after I finished the project.
- Tests could be more thorough but did not have much time to think for more one as I spent almost all Sunday between investigating and creating the project. 