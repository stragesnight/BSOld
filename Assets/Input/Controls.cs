// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Entity"",
            ""id"": ""2464bbb9-d837-4455-b45e-2c8e41797575"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""ef2e7dda-3467-431f-b2b5-dc5706a2ecf9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""2d5d4061-87f1-4e6d-bbc5-9cc142d63535"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""fbff7cb7-a3f5-4d00-8213-ba4981b046cf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""c405d16e-48b5-4b7a-a2aa-f9d92ed8fd2a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3137243d-802f-4277-b3d3-96c33cb80c78"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""965ac5fa-af5b-474a-964b-865999b11c59"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a4281de2-7d14-44a1-9e65-8b0ac9bb880d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""aa8d8725-bc61-4b0f-9ae8-8ce5e57b6b62"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""87a1e366-a773-4139-8f1b-e81ff88ffb15"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fd1e9f9f-2237-403f-af52-63e1b84390de"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4fb8f626-6bd2-4a78-994f-c5abd329f80a"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a71d2fe0-922f-4ed3-aabf-fdd94b842f98"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0001eaa2-101c-45ee-868d-0220e67947a7"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""55bb230d-5b2d-4376-bf0c-00708a1fd914"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""6019adf1-ad84-4bf7-b89e-e4affe64bff7"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""cfe352c5-0713-48f8-89a7-0520211ce289"",
                    ""path"": ""<Mouse>/position/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d3637616-f06b-4073-8ec3-bc4bbd494148"",
                    ""path"": ""<Mouse>/position/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Inventory"",
            ""id"": ""5106c146-0f86-47d9-80ec-2053e0f56bfe"",
            ""actions"": [
                {
                    ""name"": ""InventorySlot1"",
                    ""type"": ""Button"",
                    ""id"": ""c651a8fa-319f-4c58-8dc6-8f9b318d84f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InventorySlot2"",
                    ""type"": ""Button"",
                    ""id"": ""dbed87eb-a429-4d14-906d-aa5139644689"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InventorySlot3"",
                    ""type"": ""Button"",
                    ""id"": ""9af36787-8606-4352-a617-d42f8a821fef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InventorySlot4"",
                    ""type"": ""Button"",
                    ""id"": ""2df5bd03-1a02-48d4-a217-2f0b32b18038"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InventorySlot5"",
                    ""type"": ""Button"",
                    ""id"": ""77ba6f3c-3aad-4aa7-8b84-86e61b40861b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InventorySlot6"",
                    ""type"": ""Button"",
                    ""id"": ""7e12a81d-356a-4515-870b-dd8d40439504"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InventorySlot7"",
                    ""type"": ""Button"",
                    ""id"": ""ee393727-ec43-46c9-a784-c9c794c52f2b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InventorySlot8"",
                    ""type"": ""Button"",
                    ""id"": ""69c58c87-c611-44d2-990e-cb2f68af51ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InventorySlot9"",
                    ""type"": ""Button"",
                    ""id"": ""090c5a22-2f49-40d7-a413-a8b3fd430d2c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InventorySlot10"",
                    ""type"": ""Button"",
                    ""id"": ""63d3a738-bf33-4691-96d7-f2724ec9c60c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d526357a-f320-47e4-a7c2-39853e6dd8e2"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""InventorySlot1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b1f59f1-9c66-4212-a610-4d2f661a40c9"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""InventorySlot2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09c3c0c2-d815-4c19-b258-3e92be94eec6"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""InventorySlot3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""740db557-767e-4dfb-8679-21e4988e12d4"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""InventorySlot4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ffaefa6-7120-4ac2-8f27-31817692f975"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""InventorySlot5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8058ffcc-3d83-45c3-a54f-20dbb94ed5ff"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""InventorySlot6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92995684-c748-4c07-bd99-bc47359bf3f8"",
                    ""path"": ""<Keyboard>/7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""InventorySlot7"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38a06ce6-1bf8-48b3-b346-1a778c8a47af"",
                    ""path"": ""<Keyboard>/8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""InventorySlot8"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c72e7b79-d589-467d-bc3a-f73b222898c5"",
                    ""path"": ""<Keyboard>/9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""InventorySlot9"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e9e0ca1-a368-410a-8782-0711370d1e9b"",
                    ""path"": ""<Keyboard>/0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""InventorySlot10"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard + mouse"",
            ""bindingGroup"": ""Keyboard + mouse"",
            ""devices"": []
        }
    ]
}");
        // Entity
        m_Entity = asset.FindActionMap("Entity", throwIfNotFound: true);
        m_Entity_Move = m_Entity.FindAction("Move", throwIfNotFound: true);
        m_Entity_Attack = m_Entity.FindAction("Attack", throwIfNotFound: true);
        m_Entity_MousePosition = m_Entity.FindAction("MousePosition", throwIfNotFound: true);
        // Inventory
        m_Inventory = asset.FindActionMap("Inventory", throwIfNotFound: true);
        m_Inventory_InventorySlot1 = m_Inventory.FindAction("InventorySlot1", throwIfNotFound: true);
        m_Inventory_InventorySlot2 = m_Inventory.FindAction("InventorySlot2", throwIfNotFound: true);
        m_Inventory_InventorySlot3 = m_Inventory.FindAction("InventorySlot3", throwIfNotFound: true);
        m_Inventory_InventorySlot4 = m_Inventory.FindAction("InventorySlot4", throwIfNotFound: true);
        m_Inventory_InventorySlot5 = m_Inventory.FindAction("InventorySlot5", throwIfNotFound: true);
        m_Inventory_InventorySlot6 = m_Inventory.FindAction("InventorySlot6", throwIfNotFound: true);
        m_Inventory_InventorySlot7 = m_Inventory.FindAction("InventorySlot7", throwIfNotFound: true);
        m_Inventory_InventorySlot8 = m_Inventory.FindAction("InventorySlot8", throwIfNotFound: true);
        m_Inventory_InventorySlot9 = m_Inventory.FindAction("InventorySlot9", throwIfNotFound: true);
        m_Inventory_InventorySlot10 = m_Inventory.FindAction("InventorySlot10", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Entity
    private readonly InputActionMap m_Entity;
    private IEntityActions m_EntityActionsCallbackInterface;
    private readonly InputAction m_Entity_Move;
    private readonly InputAction m_Entity_Attack;
    private readonly InputAction m_Entity_MousePosition;
    public struct EntityActions
    {
        private @Controls m_Wrapper;
        public EntityActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Entity_Move;
        public InputAction @Attack => m_Wrapper.m_Entity_Attack;
        public InputAction @MousePosition => m_Wrapper.m_Entity_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_Entity; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(EntityActions set) { return set.Get(); }
        public void SetCallbacks(IEntityActions instance)
        {
            if (m_Wrapper.m_EntityActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_EntityActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_EntityActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_EntityActionsCallbackInterface.OnMove;
                @Attack.started -= m_Wrapper.m_EntityActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_EntityActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_EntityActionsCallbackInterface.OnAttack;
                @MousePosition.started -= m_Wrapper.m_EntityActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_EntityActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_EntityActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_EntityActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public EntityActions @Entity => new EntityActions(this);

    // Inventory
    private readonly InputActionMap m_Inventory;
    private IInventoryActions m_InventoryActionsCallbackInterface;
    private readonly InputAction m_Inventory_InventorySlot1;
    private readonly InputAction m_Inventory_InventorySlot2;
    private readonly InputAction m_Inventory_InventorySlot3;
    private readonly InputAction m_Inventory_InventorySlot4;
    private readonly InputAction m_Inventory_InventorySlot5;
    private readonly InputAction m_Inventory_InventorySlot6;
    private readonly InputAction m_Inventory_InventorySlot7;
    private readonly InputAction m_Inventory_InventorySlot8;
    private readonly InputAction m_Inventory_InventorySlot9;
    private readonly InputAction m_Inventory_InventorySlot10;
    public struct InventoryActions
    {
        private @Controls m_Wrapper;
        public InventoryActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @InventorySlot1 => m_Wrapper.m_Inventory_InventorySlot1;
        public InputAction @InventorySlot2 => m_Wrapper.m_Inventory_InventorySlot2;
        public InputAction @InventorySlot3 => m_Wrapper.m_Inventory_InventorySlot3;
        public InputAction @InventorySlot4 => m_Wrapper.m_Inventory_InventorySlot4;
        public InputAction @InventorySlot5 => m_Wrapper.m_Inventory_InventorySlot5;
        public InputAction @InventorySlot6 => m_Wrapper.m_Inventory_InventorySlot6;
        public InputAction @InventorySlot7 => m_Wrapper.m_Inventory_InventorySlot7;
        public InputAction @InventorySlot8 => m_Wrapper.m_Inventory_InventorySlot8;
        public InputAction @InventorySlot9 => m_Wrapper.m_Inventory_InventorySlot9;
        public InputAction @InventorySlot10 => m_Wrapper.m_Inventory_InventorySlot10;
        public InputActionMap Get() { return m_Wrapper.m_Inventory; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InventoryActions set) { return set.Get(); }
        public void SetCallbacks(IInventoryActions instance)
        {
            if (m_Wrapper.m_InventoryActionsCallbackInterface != null)
            {
                @InventorySlot1.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot1;
                @InventorySlot1.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot1;
                @InventorySlot1.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot1;
                @InventorySlot2.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot2;
                @InventorySlot2.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot2;
                @InventorySlot2.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot2;
                @InventorySlot3.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot3;
                @InventorySlot3.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot3;
                @InventorySlot3.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot3;
                @InventorySlot4.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot4;
                @InventorySlot4.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot4;
                @InventorySlot4.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot4;
                @InventorySlot5.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot5;
                @InventorySlot5.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot5;
                @InventorySlot5.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot5;
                @InventorySlot6.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot6;
                @InventorySlot6.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot6;
                @InventorySlot6.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot6;
                @InventorySlot7.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot7;
                @InventorySlot7.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot7;
                @InventorySlot7.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot7;
                @InventorySlot8.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot8;
                @InventorySlot8.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot8;
                @InventorySlot8.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot8;
                @InventorySlot9.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot9;
                @InventorySlot9.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot9;
                @InventorySlot9.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot9;
                @InventorySlot10.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot10;
                @InventorySlot10.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot10;
                @InventorySlot10.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventorySlot10;
            }
            m_Wrapper.m_InventoryActionsCallbackInterface = instance;
            if (instance != null)
            {
                @InventorySlot1.started += instance.OnInventorySlot1;
                @InventorySlot1.performed += instance.OnInventorySlot1;
                @InventorySlot1.canceled += instance.OnInventorySlot1;
                @InventorySlot2.started += instance.OnInventorySlot2;
                @InventorySlot2.performed += instance.OnInventorySlot2;
                @InventorySlot2.canceled += instance.OnInventorySlot2;
                @InventorySlot3.started += instance.OnInventorySlot3;
                @InventorySlot3.performed += instance.OnInventorySlot3;
                @InventorySlot3.canceled += instance.OnInventorySlot3;
                @InventorySlot4.started += instance.OnInventorySlot4;
                @InventorySlot4.performed += instance.OnInventorySlot4;
                @InventorySlot4.canceled += instance.OnInventorySlot4;
                @InventorySlot5.started += instance.OnInventorySlot5;
                @InventorySlot5.performed += instance.OnInventorySlot5;
                @InventorySlot5.canceled += instance.OnInventorySlot5;
                @InventorySlot6.started += instance.OnInventorySlot6;
                @InventorySlot6.performed += instance.OnInventorySlot6;
                @InventorySlot6.canceled += instance.OnInventorySlot6;
                @InventorySlot7.started += instance.OnInventorySlot7;
                @InventorySlot7.performed += instance.OnInventorySlot7;
                @InventorySlot7.canceled += instance.OnInventorySlot7;
                @InventorySlot8.started += instance.OnInventorySlot8;
                @InventorySlot8.performed += instance.OnInventorySlot8;
                @InventorySlot8.canceled += instance.OnInventorySlot8;
                @InventorySlot9.started += instance.OnInventorySlot9;
                @InventorySlot9.performed += instance.OnInventorySlot9;
                @InventorySlot9.canceled += instance.OnInventorySlot9;
                @InventorySlot10.started += instance.OnInventorySlot10;
                @InventorySlot10.performed += instance.OnInventorySlot10;
                @InventorySlot10.canceled += instance.OnInventorySlot10;
            }
        }
    }
    public InventoryActions @Inventory => new InventoryActions(this);
    private int m_KeyboardmouseSchemeIndex = -1;
    public InputControlScheme KeyboardmouseScheme
    {
        get
        {
            if (m_KeyboardmouseSchemeIndex == -1) m_KeyboardmouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard + mouse");
            return asset.controlSchemes[m_KeyboardmouseSchemeIndex];
        }
    }
    public interface IEntityActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
    public interface IInventoryActions
    {
        void OnInventorySlot1(InputAction.CallbackContext context);
        void OnInventorySlot2(InputAction.CallbackContext context);
        void OnInventorySlot3(InputAction.CallbackContext context);
        void OnInventorySlot4(InputAction.CallbackContext context);
        void OnInventorySlot5(InputAction.CallbackContext context);
        void OnInventorySlot6(InputAction.CallbackContext context);
        void OnInventorySlot7(InputAction.CallbackContext context);
        void OnInventorySlot8(InputAction.CallbackContext context);
        void OnInventorySlot9(InputAction.CallbackContext context);
        void OnInventorySlot10(InputAction.CallbackContext context);
    }
}
