using UnityEngine;

namespace Assets.Scripts.SaveSystem
{
    public class SaveTest : MonoBehaviour
    { 
        private void Awake()
        {
/*
            Test t = new Test() {x = 10, y = 10};
            Test a = new Test() {x = 31, y = 31};

            Node c = new Node() {pos = Vector3.back};
            Node d = new Node() {pos = Vector3.forward};
               
            SaveSystem<Test>.Instance.SaveData(t,"test");
            SaveSystem<Test>.Instance.SaveData(a, "test1");

            SaveSystem<Node>.Instance.SaveData(c,"node");
            SaveSystem<Node>.Instance.SaveData(d,"node1");
            */
            /*

            var test = _test.GetDataWithDict("nodata");
            if(test == null)
                Debug.Log("null");
            else    
                Debug.Log("not null");*/
        }

        private void Start()
        {
            /*
            Test t = SaveSystem<Test>.Instance.GetDataWithDict("test");
            Test a = SaveSystem<Test>.Instance.GetDataWithDict("test1");

            Node c = SaveSystem<Node>.Instance.GetDataWithDict("node");
            Node d = SaveSystem<Node>.Instance.GetDataWithDict("node1");

            Debug.Log($"{t.x} , {t.y}");
            Debug.Log($"{a.x} , {a.y}");

            Debug.Log(c.pos);
            Debug.Log(d.pos);
            */

            Test a = new Test() {x = 31, y = 31};
            SaveSystem.SaveData(a, "v2");
            Test b = new Test() {x = 32, y = 32};
            SaveSystem.SaveData(b, "v2");

            Debug.Log($"{SaveSystem.GetOrCreateData<Test>("v2").x}, {SaveSystem.GetOrCreateData<Test>("v2").x}");

            //var t = SaveSystem.GetOrCreateData<Test>("nodata");
            //Debug.Log($"{t.GetType().ToString()} {t.x} , {t.y}");
/*
            int score = 0;
            SaveSystem.SaveData(score, "score");

            var s = SaveSystem.GetOrCreateData<int>("score");
            */
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Test a = new Test() {x = 99, y = 99};

                //_test.SaveData(a,"RunTimeTest");
                //SaveSystem<Test>.Instance.SaveData(a, "runtimeTest");
                SaveSystem.SaveData(a, "runtime");
            }
        }
/*
        private void OnDestroy()
        {
            _test.Destroy();
            _node.Destroy();
        }
        */
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
