# PersistentDictionary Sample

Here is an application that remembers a first name -> last name mapping in a persistent dictionary.

```vb.net
Imports Microsoft.Isam.Esent.Collections.Generic

Module PersistentDictionarySample

  Sub Main()
    Dim dictionary As PersistentDictionary(Of String, String) = New PersistentDictionary(Of String, String)("Names")
    Console.WriteLine("What is your first name?")
    Dim firstName As String = Console.ReadLine()
    If dictionary.ContainsKey(firstName) Then
      Console.WriteLine("Welcome back {0} {1}", firstName, dictionary(firstName))
    Else
      Console.WriteLine("I don't know you, {0}. What is your last name?", firstName)
      dictionary(firstName) = Console.ReadLine()
    End If
  End Sub

End Module
```
