using UnityEngine;

namespace Assets.Scripts.SaveSystem
{
    public class SaveTest : MonoBehaviour
    {
        private SaveSystem<Test> test;
        private SaveSystem<Node> node;

        private void Awake()
        {
            test = SaveSystem<Test>.Instance;
            node = SaveSystem<Node>.Instance;

            Test t = new Test() {x = 10, y = 10};
            Test a = new Test() {x = 31, y = 31};

            Node c = new Node() {pos = Vector3.back};
            Node d = new Node() {pos = Vector3.forward};
               
            test.SaveData(t,"test");
            test.SaveData(a, "test1");

            node.SaveData(c,"node");
            node.SaveData(d,"node1");
        }

        private void Start()
        {
            Test t = test.GetDataWithDict("test");
            Test a = test.GetDataWithDict("test1");

            Node c = node.GetDataWithDict("node");
            Node d = node.GetDataWithDict("node1");

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

                test.SaveData(a,"RunTimeTest");
            }
        }

        private void OnDestroy()
        {
            test.Destroy();
            node.Destroy();
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
