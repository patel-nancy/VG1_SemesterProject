using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class CustomerProfile : MonoBehaviour
{
    public static CustomerProfile instance;
    
    static readonly string[] Names = { "Agnes", "Mary", "Thomas", "John", "Martha" };
    public GameObject[] spriteOptions;

    public string customerName;
    public GameObject customer;
    
    void Awake() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }

    }
    
    void Start()
    {
        instance = this;
    }
    
    public void GenerateCustomer()
    {
        // Randomize name
        customerName = Names[Random.Range(0, Names.Length)];
        
        int idx = Random.Range(0, spriteOptions.Length);
        customer = Instantiate(spriteOptions[idx], transform);
    }

    public void Hide()
    {
        customer.SetActive(false);
    }

    public void Show()
    {
        customer.SetActive(true);
    }
}
