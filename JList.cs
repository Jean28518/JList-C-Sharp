using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.JList {
    /// <summary>
    /// Objekt Liste
    /// </summary>
    public class JList<T> {
        // Dummy ListItem.
        public class ListItem {
            T data;

            protected internal ListItem (T d) {
                data = d;
            }
            public T GetData() {
                return data;
            }
        }

        public int active = -1;

        public List<T> list {set; get;}

        /// <summary>
        /// Liste zum Verwalten von allen Objektarten
        /// </summary>
        public JList() {
            list = new List<T>();
        }

        public JList(List<T> list) {
            this.list = list;
        }

        /// <summary>
        /// Gibt den Inhalt der Liste auf der Console aus
        /// </summary>
        public void PrintList() {
            foreach (T item in list) {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Fügt ein Objekt der Liste hinzu
        /// </summary>
        /// <param name="data"></param>
        public void AppendElement(T data) {
            if (data == null) {
                // Print.MethodHistory();
                throw new System.ArgumentException("Warnung: neues Listenobjekt == null!");
            }
            list.Add(data);
            // Here the 'active' could be set too, but in Implementation of Janick the set of active makes no sense..
        }


        public void AppendElement() {
            throw new System.ArgumentException("Warnung: neues Listenobjekt == null!");
        }

        /// <summary>
        /// Liefert ein Element, dass an einer bestimmten Position der Liste steht
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public ListItem GetElementAt(int pos) {
            if (pos < 0) {
                return null;
            }
            active = pos;
            return new ListItem(list[pos]);
        }

        /// <summary>
        /// Fügt eine Liste am Ende der Liste an.
        /// </summary>
        /// <param name="l"></param>
        public void AppendJList(JList<T> l) {
            foreach(T item in l.list) {
                list.Add(item);
                // Here the 'active' could be set too...
            }
        }

        /// <summary>
        ///  Returns a cutout of the list from start to end
        /// </summary>
        /// <param> start First Element </param>
        /// <param> end Last Element </param>
        /// <returns> Liste of ListItems from start till end </returns>
        public JList<T> GetValues(int start, int end) {
            JList<T> returnValue = new JList<T>();
            int count = end - start + 1;
            return new JList<T>(list.GetRange(start, count));
        }

        /// <summary>
        /// Vertauscht zwei Elemente miteinander
        /// </summary>
        /// <param name="posA"></param>
        /// <param name="posB"></param>
        public void ExchangeValues (int posA, int posB) {
            T tmp = list[posA];
            list[posA] = list[posB];
            list[posB] = tmp;
        }

        /// <summary>
        /// Erstellt eine neue Liste und fügt dieser die Daten der List hinzu
        /// </summary>
        /// <returns>Neue Liste</returns>
        public JList<T> Clone() {
            List<T> newList = new List<T>();
            T[] array = new T[list.Count];
            list.CopyTo(array);
            newList.AddRange(array);
            JList<T> returnValue = new JList<T>(newList);
            returnValue.active = this.active;
            return returnValue;
        }

        /// <summary>
        /// Löscht das aktive Element der Liste
        /// </summary>
        /// <returns></returns>
        public ListItem CutActiveElement() {
            return CutElementAt(active);
        }

        public T RemoveValueAt(int index) {
            T returnValue =list[index];
            list.RemoveAt(index);
            return returnValue;
        }

        /// <summary>
        /// Löscht das Element an der übergebenen Position
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public ListItem CutElementAt(int index) {
            ListItem tmp = new ListItem(list[index]);
            list.RemoveAt(index);
            return tmp;
        }

        public void DeleteActiveElement() {
            CutActiveElement();
        }


        /// <summary>
        /// Inserts ListItem bevore the active element
        /// </summary>
        /// <param>data ListItem</param>
        public void InsertElementBeforeActive(T data) {
            list.Insert(active, data);
            active += 1; //update Index of active, because the "active element" where moved one "step further on"
        }

        public void InsertValueBefore(int index, T data) {
            list.Insert(index, data);
            if (active >= index) {
                active += 1;
            }
        }

        /// <summary>
        /// Das letzte Element wird das aktive Element
        /// </summary>
        public void GoToLastElement() {
            active = list.Count -1;
        }

        /// <summary>
        /// Gibt die Länge der Liste als int zurück
        /// </summary>
        /// <returns></returns>
        public int Length() {
            return list.Count;
        }

        /// <summary>
        /// Gibt die Länge der Liste als int zurück
        /// </summary>
        public int Size() {
            return Length();
        }

        /// <summary>
        /// Das nächste Element wird das aktive Element der Liste.
        /// </summary>
        /// <returns></returns>
        public void Next() {
            if ((active) < list.Count) {
                active += 1;
            }
        }

        /// <summary>
        /// Das vorherige Element wird das aktive Element der Liste
        /// </summary>
        /// <returns></returns>
        public void Prev() {
            if ((active) >= 0) {
                active -= 1;
            }
        }

        /// <summary>
        /// Setzt die Liste zurück: Erstes Element = aktives Element
        /// </summary>
        public void Rewind() {
            active = 0;
        }

        /// <summary>
        /// Deletes the given object of the list.
        /// </summary>
        public bool RemoveValue(T data) {
            if (!Contains(data)) {
                return false;
            }
            CutElementAt(IndexOf(data));
            return true;
        }

        /// <summary>
        /// Returns true if the object is in the list
        /// Die hierfür benutzte Methode IndexOf nutzt eine kopie der eigentlichen Liste
        /// Active bleibt active
        /// </summary>
        public bool Contains(T data) {
            return list.Contains(data);
        }

        /// <summary>
        /// Returns the number of the object in the list or -1, if object not found in list.
        /// </summary>
        public int IndexOf(T data) {
            if (data == null) {
                throw new System.ArgumentException("Warnung: Indexabfrage eines Listenobjekt == null!");
            }

            if (!Contains(data)) {
                return -1;
            }
            return list.IndexOf(data);
        }

        /// <summary>
        /// Sets the specific object to the active element
        /// </summary>
        public bool SetActive(T data) {
            if (!Contains(data)) {
                // Print.MethodHistory();
                throw new System.ArgumentException("- Attention: - List.SetActive of on abject, which is not in the List");
            }
            active = list.IndexOf(data);
            return true;
        }

        public void SetActive(int i) {
            if (i < 0 || i >= list.Count) {
                throw new System.ArgumentException("- Attention: - List.SetActive of on index which is out of range: " + i);
            }
            active = i;
        }

        /// <summary>
        /// Liefert das aktive Element der Liste zurück
        /// </summary>
        /// <returns> ListItem </returns>
        public ListItem GetActiveElement() {
            if (active < 0 || active >= list.Count) {
                return null;
            }
            return new ListItem(list[active]);

        }

        /// <summary>
        /// Ersetzt die Frühere SetBoolean, SetList, und SetNumber:
        /// Setzt an der übergebenen Position den 'data' Wert ein.
        /// Ist position > Länge der Liste, werden alle fehlenden Werte bis dahin auf 'empty' gesetzt.
        /// Beispiel für die alte SetNumber(30, 45):     SetDataToPosition(30, -1, 45);
        /// </summary>
        /// <param name="position">Position in der liste</param>
        /// <param name="empty">Das Element, welches bis zur Position der Liste immer eingesetzt wird, sollten Einträge bis dahin noch nicht existieren.</param>
        /// <param name="data">Das Element, was an der Position der Liste eingefügt wird</param>
        public void SetDataToPosition (int position, T empty, T data) {
            if (Length() <= position) {
                for (int i = Length() - 1; i < position; i++) {
                    list.Add(empty);
                }
                list.Add(data);
                return;
            }
            list[position] = data;
        }

        /// <summary>
        /// Liste auf auf den angegebenen Bereich zwischen Position A und Position B reduziert.
        /// </summary>
        /// <param name="posA"></param>
        /// <param name="posB"></param>
        public void CutList(int posA, int posB) {
            List<T> newList = new List<T>();
            T[] array = new T[posB - posA+1];
            list.CopyTo(posA, array, 0, posB - posA+1);
            newList.AddRange(array);
            list.Clear();
            list = newList;
        }

        public T GetValueAt(int index) {
            if (index < 0 || index >= Length()) {
                Console.WriteLine("JList: Index " + index +  " out of range! Length of JList: " + Length() + " Crashing...");
            }
            return list[index];
        }

        public void SetValue(int index, T value) {
            list[index] = value;
        }

        public void Add(T value) {
            list.Add(value);
        }

        public void Empty() {
            list.Clear();
            active = -1;
        }

        /// <summary>
        /// Attention ! If you write something to this array, the JList won't changed.
        /// </summary>
        public T[] GetArray() {
            return list.ToArray();
        }


        public T GetLast() {
            if (Size() >= 1)
            {
                return GetValueAt(Size()-1);
            } else {
                return default(T);
            }
        }

    }



}
