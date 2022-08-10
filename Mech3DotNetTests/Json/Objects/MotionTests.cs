using Mech3DotNet.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using static Mech3DotNetTests.Json.Helpers;

namespace Mech3DotNetTests.Json
{
    [TestClass]
    public class MotionTests
    {
        [TestMethod]
        public void SerDe_Default_Roundtrips()
        {
            var expected = Normalize(@"{
    'loop_time': 2.0,
    'parts': [
        [
            'part',
            [
                {
                    'translation' : [0.1, 0.2, 0.3],
                    'rotation': [0.1, 0.2, 0.3, 0.4]
                }
            ]
        ]
    ],
    'frame_count': 1
}");
            var converter = Motion<Vec3, Vec4>.GetConverter();
            var motion = JsonConvert.DeserializeObject<Motion<Vec3, Vec4>>(expected, converter);
            Assert.AreEqual(2.0f, motion.loopTime, 0.001f);
            Assert.AreEqual(1, motion.frameCount);
            Assert.AreEqual(1, motion.parts.Count);
            var part = motion.parts[0];
            Assert.AreEqual("part", part.name);
            Assert.AreEqual(1, part.frames.Count);
            var frame = part.frames[0];
            Assert.AreEqual(new Vec3(0.1f, 0.2f, 0.3f), frame.translation);
            Assert.AreEqual(new Vec4(0.1f, 0.2f, 0.3f, 0.4f), frame.rotation);
            var actual = JsonConvert.SerializeObject(motion, converter);
            Assert.AreEqual(expected, actual);
        }
    }
}
