# Behavioral_DesignPatterns
In acest proiect am folosit Behavior Design Patern Command si Observer:

# Pattern-ul Command
Pattern-ul Command este un pattern comportamental care vă permite să încapsulați acțiuni sau solicitări ca obiecte, care pot fi transmise, stocate și executate la un moment ulterior. Pattern-ul constă din mai multe componente:

•Interfața ICommand, care definește contractul pentru obiectele de comandă. Interfața declară două metode: Execute() și Undo(). Metoda Execute() este utilizată pentru a executa comanda, în timp ce metoda Undo() este utilizată pentru a anula comanda.

•Clasa ChangeStatusCommand, care implementează interfața ICommand. Clasa reprezintă o comandă care schimbă starea unui obiect Task. Metoda Execute() schimbă starea obiectului Task la o nouă stare, în timp ce metoda Undo() revine starea obiectului Task la starea sa anterioară.

# Pattern-ul Observer
Pattern-ul Observer este un pattern comportamental care vă permite să definiți o dependență de tipul unu-la-mulți între obiecte, astfel încât atunci când un obiect schimbă starea, toți dependenții să fie notificați și actualizați automat. Pattern-ul constă din mai multe componente:

•Interfața ISubject, care definește contractul pentru obiectele de subiect. Interfața declară trei metode: Attach(), Detach() și Notify(). Metoda Attach() este utilizată pentru a atașa un observator subiectului, în timp ce metoda Detach() este utilizată pentru a detasa un observator de la subiect. Metoda Notify() este utilizată pentru a notifica toți observatorii că subiectul a fost modificat.

•Interfața IObserver, care definește contractul pentru obiectele de observator. Interfața declară o metodă: Update(). Metoda Update() este utilizată pentru a actualiza observatorul cu informații noi din subiect.

•Clasa Task, care implementează interfața ISubject. Clasa reprezintă o sarcină care poate fi observată de utilizatori. Metoda AddComment() este utilizată pentru a adăuga comentarii la sarcină, în timp ce metoda ChangeStatus() este utilizată pentru a schimba starea sarcinii. Metoda Attach() este utilizată pentru a atașa un observator subiectului, în timp ce metoda Detach() este utilizată pentru a detasa un observator de la subiect. Metoda Notify() este utilizată pentru a notifica toți observatorii că sarcina a fost modificată.

•Clasa User, care implementează interfața IObserver. Clasa reprezintă un utilizator care poate observa o sarcină. Metoda Update() este utilizată pentru a actualiza utilizatorul cu informații noi din sarcină.
