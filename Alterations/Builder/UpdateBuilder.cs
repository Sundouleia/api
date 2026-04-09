namespace SundouleiaAPI.Alterations;

// Builder class to help construct the sent update records from existing data.
public class IpcUpdateBuilder
{
    private IpcKind _updates;
    private string _glamourState = string.Empty;
    private string _cPlusState = string.Empty;
    private string _lociData = string.Empty;

    // Player-specific
    private string _modManips = string.Empty;
    private string _heelsOffset = string.Empty;
    private string _titleData = string.Empty;
    private string _moodleData = string.Empty;
    private string _petNicks = string.Empty;

    public IpcKind Updates => _updates;

    public IpcUpdateBuilder WithGlamour(string glamourState)
    {
        _glamourState = glamourState;
        _updates |= IpcKind.Glamourer;
        return this;
    }

    public IpcUpdateBuilder WithCPlus(string cPlusState)
    {
        _cPlusState = cPlusState;
        _updates |= IpcKind.CPlus;
        return this;
    }

    public IpcUpdateBuilder WithManips(string modManips)
    {
        _modManips = modManips;
        _updates |= IpcKind.ModManips;
        return this;
    }

    public IpcUpdateBuilder WithHeels(string heelsOffset)
    {
        _heelsOffset = heelsOffset;
        _updates |= IpcKind.Heels;
        return this;
    }

    public IpcUpdateBuilder WithTitle(string titleData)
    {
        _titleData = titleData;
        _updates |= IpcKind.Honorific;
        return this;
    }

    public IpcUpdateBuilder WithLoci(string lociData)
    {
        _lociData = lociData;
        _updates |= IpcKind.Loci;
        return this;
    }

    public IpcUpdateBuilder WithMoodles(string moodleData)
    {
        _moodleData = moodleData;
        _updates |= IpcKind.Moodles;
        return this;
    }

    public IpcUpdateBuilder WithPetNicks(string petNicks)
    {
        _petNicks = petNicks;
        _updates |= IpcKind.PetNames;
        return this;
    }

    public IpcDataUpdate? BuildNonPlayer()
    {
        if (_updates == IpcKind.None)
            return null;
        // limit the updates to only allow Glamour and CPlus.
        var updates = _updates & (IpcKind.Glamourer | IpcKind.CPlus | IpcKind.Loci);
        return new IpcDataUpdate(updates)
        {
            GlamourState = _glamourState,
            CPlusState = _cPlusState,
            Loci = _lociData
        };
    }

    public IpcDataPlayerUpdate? BuildPlayer()
    {
        if (_updates == IpcKind.None)
            return null;
        return new IpcDataPlayerUpdate(_updates)
        {
            GlamourState = _glamourState,
            CPlusState = _cPlusState,
            Loci = _lociData,

            ModManips = _modManips,
            HeelsOffset = _heelsOffset,
            TitleData = _titleData,
            Moodles = _moodleData,
            PetNicks = _petNicks
        };
    }
}