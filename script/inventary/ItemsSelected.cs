using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSelected : MonoBehaviour
{
    [SerializeField] Transform ItemCellTransform;

    [SerializeField] GameObject Buda;
    [SerializeField] GameObject Counts;
    [SerializeField] GameObject Ilumination;
    [SerializeField] GameObject Inciense;
    [SerializeField] GameObject Ropes;
    [SerializeField] GameObject Sandals;
    private void Start()
    {
        PlayerPrefs.SetInt("Buda", 0);
        PlayerPrefs.SetInt("Counts", 0);
        PlayerPrefs.SetInt("Ilumination", 0);
        PlayerPrefs.SetInt("Inciense", 0);
        PlayerPrefs.SetInt("Ropes", 0);
        PlayerPrefs.SetInt("Sandals", 0);
    }
    void Update()
    {
        if (transform.childCount == 1)
        {
            if (Buda.transform.IsChildOf(ItemCellTransform))
            {
                var Buda = true;

                PlayerPrefs.SetInt("Buda", Buda ? 1 : 0);
                
                Buda = PlayerPrefs.GetInt("Buda") == 1 ? true : false;
            }

            if (Counts.transform.IsChildOf(ItemCellTransform))
            {
                var Counts = true;
                PlayerPrefs.SetInt("Counts", Counts ? 1 : 0);

                Counts = PlayerPrefs.GetInt("Counts") == 1 ? true : false;
            }

            if (Ilumination.transform.IsChildOf(ItemCellTransform))
            {
                var Ilumination = true;
                PlayerPrefs.SetInt("Ilumination", Ilumination ? 1 : 0);

                Ilumination = PlayerPrefs.GetInt("Ilumination") == 1 ? true : false;
            }

            if (Inciense.transform.IsChildOf(ItemCellTransform))
            {
                var Inciense = true;
                PlayerPrefs.SetInt("Inciense", Inciense ? 1 : 0);

                Inciense = PlayerPrefs.GetInt("Inciense") == 1 ? true : false;

            }

            if (Ropes.transform.IsChildOf(ItemCellTransform))
            {
                var Ropes = true;
                PlayerPrefs.SetInt("Ropes", Ropes ? 1 : 0);

                Ropes = PlayerPrefs.GetInt("Ropes") == 1 ? true : false;
            }

            if (Sandals.transform.IsChildOf(ItemCellTransform))
            {
                var Sandals = true;
                PlayerPrefs.SetInt("Sandals", Sandals ? 1 : 0);

                Sandals = PlayerPrefs.GetInt("Sandals") == 1 ? true : false;
            }
        }
    }
}
