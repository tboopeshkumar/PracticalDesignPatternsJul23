
interface IVault {
    void SetSecret(string key, object value);
    object GetSecret(string key);
}

class Vault: IVault  {
    private Dictionary<string, object> secrets = new();

    public void SetSecret(string key, object value) {
        secrets.Add(key, value);
    }

    public object GetSecret(string key) {
        return secrets[key];
    }
}

class VaultProxy : IVault
{
    private int getAccessCount = 0;
    private int setAccessCount = 0;

    private readonly IVault vault;
    public VaultProxy(IVault vault) {
        this.vault = vault;
    }

    public object GetSecret(string key)
    {
        System.Console.WriteLine($"Vault accessed {++getAccessCount} time(s) and last accessed on {DateTime.Now}");
        return vault.GetSecret(key);
    }

    public void SetSecret(string key, object value)
    {
        System.Console.WriteLine($"Vault sets value {++setAccessCount} time(s) and last updated on {DateTime.Now}");
        vault.SetSecret(key, value);
    }
}

class ProxyDemo
{
    static void Main(string[] args)
    {
        var vault = new Vault();
        var vaultProxy = new VaultProxy(vault);
        vaultProxy.SetSecret("Swiss Bank Account", "11928001838");
        Console.WriteLine(vaultProxy.GetSecret("Swiss Bank Account"));
    }
}
