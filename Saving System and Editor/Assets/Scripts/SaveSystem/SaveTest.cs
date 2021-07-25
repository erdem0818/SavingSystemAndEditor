using UnityEngine;

namespace Assets.Scripts.SaveSystem
{
    public class SaveTest : MonoBehaviour
    {
        private SaveSystem<Test> _test;
        private SaveSystem<Node> _node;

        private void Awake()
        {
            _test = SaveSystem<Test>.Instance;
            _node = SaveSystem<Node>.Instance;

            Test t = new Test() {x = 10, y = 10};
            Test a = new Test() {x = 31, y = 31};

            Node c = new Node() {pos = Vector3.back};
            Node d = new Node() {pos = Vector3.forward};
               
            _test.SaveData(t,"test");
            _test.SaveData(a, "test1");

            _node.SaveData(c,"node");
            _node.SaveData(d,"node1");
        }

        private void Start()
        {
            Test t = _test.GetDataWithDict("test");
            Test a = _test.GetDataWithDict("test1");

            Node c = _node.GetDataWithDict("node");
            Node d = _node.GetDataWithDict("node1");

            Debug.Log($"{t.x} , {t.y}");
            Debug.Log($"{a.x} , {a.y}");

            Debug.Log(c.pos);
            Debug.Log(d.pos);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Test a = new Test() {x = 99, y = 99};

                _test.SaveData(a,"RunTimeTest");
            }
        }

        private void OnDestroy()
        {
            _test.Destroy();
            _node.Destroy();
        }
    }

    public class Test
    {
        public int x, y;

        public override string ToString()
        {
            return $"{x}, {y}";
        }
    }

    public class Node
    {
        public Vector3 pos;

        public override string ToString()
        {
            return pos.ToString();
        }
    }
}
