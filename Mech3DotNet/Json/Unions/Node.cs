using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    public enum NodeType
    {
        Camera,
        Display,
        Empty,
        Light,
        Lod,
        Object3d,
        Window,
        World,
    }

    public class Node<N> : IDiscriminatedUnion
    {
        [Guid("918EF3A0-6941-4D1D-86E4-8A05CC14E6C4")]
        public sealed class Camera
        {
            [JsonProperty("name", Required = Required.Always)]
            public string name;
            [JsonProperty("clip", Required = Required.Always)]
            public Range clip;
            [JsonProperty("fov", Required = Required.Always)]
            public Range fov;
            [JsonProperty("data_ptr", Required = Required.Always)]
            public uint dataPtr;

            public Camera(string name, Range clip, Range fov, uint dataPtr)
            {
                this.name = name;
                this.clip = clip;
                this.fov = fov;
                this.dataPtr = dataPtr;
            }

            [JsonConstructor]
            private Camera() { }
        }

        [Guid("4379B467-7B37-444F-A1F3-AECD92AA5E55")]
        public sealed class Display
        {
            [JsonProperty("name", Required = Required.Always)]
            public string name;
            [JsonProperty("resolution", Required = Required.Always)]
            public Resolution resolution;
            [JsonProperty("clear_color", Required = Required.Always)]
            public Color clearColor;
            [JsonProperty("data_ptr", Required = Required.Always)]
            public uint dataPtr;

            public Display(string name, Resolution resolution, Color clearColor, uint dataPtr)
            {
                this.name = name;
                this.resolution = resolution;
                this.clearColor = clearColor;
                this.dataPtr = dataPtr;
            }

            [JsonConstructor]
            private Display() { }
        }

        [Guid("EE8996D8-D6EC-42BF-B91E-747A39DD2C16")]
        public sealed class Empty
        {
            [JsonProperty("name", Required = Required.Always)]
            public String name;
            [JsonProperty("flags", Required = Required.Always)]
            public NodeFlags flags;
            [JsonProperty("unk044", Required = Required.Always)]
            public uint unk044;
            [JsonProperty("zone_id", Required = Required.Always)]
            public uint zoneId;
            [JsonProperty("unk116", Required = Required.Always)]
            public Block unk116;
            [JsonProperty("unk140", Required = Required.Always)]
            public Block unk140;
            [JsonProperty("unk164", Required = Required.Always)]
            public Block unk164;
            [JsonProperty("parent", Required = Required.Always)]
            public uint parent;

            public Empty(string name, NodeFlags flags, uint unk044, uint zoneId, Block unk116, Block unk140, Block unk164, uint parent)
            {
                this.name = name;
                this.flags = flags;
                this.unk044 = unk044;
                this.zoneId = zoneId;
                this.unk116 = unk116;
                this.unk140 = unk140;
                this.unk164 = unk164;
                this.parent = parent;
            }

            [JsonConstructor]
            private Empty() { }
        }

        [Guid("338362FB-A134-4FEC-B6C7-C2181117A0D1")]
        public sealed class Light
        {
            [JsonProperty("name", Required = Required.Always)]
            public string name;
            [JsonProperty("direction", Required = Required.Always)]
            public Vec3 direction;
            [JsonProperty("diffuse", Required = Required.Always)]
            public float diffuse;
            [JsonProperty("ambient", Required = Required.Always)]
            public float ambient;
            [JsonProperty("color", Required = Required.Always)]
            public Color color;
            [JsonProperty("range", Required = Required.Always)]
            public Range range;
            [JsonProperty("parent_ptr", Required = Required.Always)]
            public uint parentPtr;
            [JsonProperty("data_ptr", Required = Required.Always)]
            public uint dataPtr;

            public Light(string name, Vec3 direction, float diffuse, float ambient, Color color, Range range, uint parentPtr, uint dataPtr)
            {
                this.name = name;
                this.direction = direction;
                this.diffuse = diffuse;
                this.ambient = ambient;
                this.color = color;
                this.range = range;
                this.parentPtr = parentPtr;
                this.dataPtr = dataPtr;
            }

            [JsonConstructor]
            private Light() { }
        }

        [Guid("AB4C3FD9-FD5D-4BE2-B35F-EE0581E1FE23")]
        public sealed class Lod
        {
            [JsonProperty("name", Required = Required.Always)]
            public string name;
            [JsonProperty("level", Required = Required.Always)]
            public bool level;
            [JsonProperty("range", Required = Required.Always)]
            public Range range;
            [JsonProperty("unk60", Required = Required.Always)]
            public float unk60;
            [JsonProperty("unk76", Required = Required.AllowNull)]
            public uint? unk76;
            [JsonProperty("flags", Required = Required.Always)]
            public NodeFlags flags;
            [JsonProperty("zone_id", Required = Required.Always)]
            public uint zoneId;
            [JsonProperty("area_partition", Required = Required.AllowNull)]
            public AreaPartition? areaPartition;
            [JsonProperty("parent", Required = Required.Always)]
            public uint parent;
            [JsonProperty("children", Required = Required.Always)]
            public List<uint> children;
            [JsonProperty("data_ptr", Required = Required.Always)]
            public uint dataPtr;
            [JsonProperty("parent_array_ptr", Required = Required.Always)]
            public uint parentArrayPtr;
            [JsonProperty("children_array_ptr", Required = Required.Always)]
            public uint childrenArrayPtr;
            [JsonProperty("unk116", Required = Required.Always)]
            public Block unk116;

            public Lod(string name, bool level, Range range, float unk60, uint? unk76, NodeFlags flags, uint zoneId, AreaPartition? areaPartition, uint parent, List<uint> children, uint dataPtr, uint parentArrayPtr, uint childrenArrayPtr, Block unk116)
            {
                this.name = name;
                this.level = level;
                this.range = range;
                this.unk60 = unk60;
                this.unk76 = unk76;
                this.flags = flags;
                this.zoneId = zoneId;
                this.areaPartition = areaPartition;
                this.parent = parent;
                this.children = children;
                this.dataPtr = dataPtr;
                this.parentArrayPtr = parentArrayPtr;
                this.childrenArrayPtr = childrenArrayPtr;
                this.unk116 = unk116;
            }

            [JsonConstructor]
            private Lod() { }
        }

        [Guid("690E50D1-D58C-4615-BBCA-D537EE40B52C")]
        public sealed class Object3d
        {
            [JsonProperty("name", Required = Required.Always)]
            public String name;
            [JsonProperty("transformation", Required = Required.AllowNull)]
            public Transformation? transformation;
            [JsonProperty("matrix_signs", Required = Required.Always)]
            public uint matrixSigns;
            [JsonProperty("flags", Required = Required.Always)]
            public NodeFlags flags;
            [JsonProperty("zone_id", Required = Required.Always)]
            public uint zoneId;
            [JsonProperty("area_partition", Required = Required.AllowNull)]
            public AreaPartition? areaPartition;
            [JsonProperty("mesh_index", Required = Required.Always)]
            public int meshIndex;
            [JsonProperty("parent", Required = Required.AllowNull)]
            public uint? parent;
            [JsonProperty("children", Required = Required.Always)]
            public List<N> children;
            [JsonProperty("data_ptr", Required = Required.Always)]
            public uint dataPtr;
            [JsonProperty("parent_array_ptr", Required = Required.Always)]
            public uint parentArrayPtr;
            [JsonProperty("children_array_ptr", Required = Required.Always)]
            public uint childrenArrayPtr;
            [JsonProperty("unk116", Required = Required.Always)]
            public Block unk116;
            [JsonProperty("unk140", Required = Required.Always)]
            public Block unk140;
            [JsonProperty("unk164", Required = Required.Always)]
            public Block unk164;

            public Object3d(string name, Transformation? transformation, uint matrixSigns, NodeFlags flags, uint zoneId, AreaPartition? areaPartition, int meshIndex, uint? parent, List<N> children, uint dataPtr, uint parentArrayPtr, uint childrenArrayPtr, Block unk116, Block unk140, Block unk164)
            {
                this.name = name;
                this.transformation = transformation;
                this.matrixSigns = matrixSigns;
                this.flags = flags;
                this.zoneId = zoneId;
                this.areaPartition = areaPartition;
                this.meshIndex = meshIndex;
                this.parent = parent;
                this.children = children;
                this.dataPtr = dataPtr;
                this.parentArrayPtr = parentArrayPtr;
                this.childrenArrayPtr = childrenArrayPtr;
                this.unk116 = unk116;
                this.unk140 = unk140;
                this.unk164 = unk164;
            }

            [JsonConstructor]
            private Object3d() { }
        }

        [Guid("54F6B188-C397-409D-999D-992A2893A412")]
        public sealed class Window
        {
            [JsonProperty("name", Required = Required.Always)]
            public string name;
            [JsonProperty("resolution", Required = Required.Always)]
            public Resolution resolution;
            [JsonProperty("data_ptr", Required = Required.Always)]
            public uint dataPtr;

            public Window(string name, Resolution resolution, uint dataPtr)
            {
                this.name = name;
                this.resolution = resolution;
                this.dataPtr = dataPtr;
            }

            [JsonConstructor]
            private Window() { }
        }

        [Guid("64BA0740-6702-438C-A546-3D52437B7472")]
        public sealed class World
        {
            [JsonProperty("name", Required = Required.Always)]
            public String name;
            [JsonProperty("area", Required = Required.Always)]
            public Area area;
            [JsonProperty("partitions", Required = Required.Always)]
            public List<List<Partition>> partitions;
            [JsonProperty("area_partition_x_count", Required = Required.Always)]
            public uint areaPartitionXCount;
            [JsonProperty("area_partition_y_count", Required = Required.Always)]
            public uint areaPartitionYCount;
            [JsonProperty("fudge_count", Required = Required.Always)]
            public bool fudgeCount;
            [JsonProperty("area_partition_ptr", Required = Required.Always)]
            public uint areaPartitionPtr;
            [JsonProperty("virt_partition_ptr", Required = Required.Always)]
            public uint virtPartitionPtr;
            [JsonProperty("world_children_ptr", Required = Required.Always)]
            public uint worldChildrenPtr;
            [JsonProperty("world_child_value", Required = Required.Always)]
            public uint worldChildValue;
            [JsonProperty("world_lights_ptr", Required = Required.Always)]
            public uint worldLightsPtr;
            [JsonProperty("children", Required = Required.Always)]
            public List<uint> children;
            [JsonProperty("data_ptr", Required = Required.Always)]
            public uint dataPtr;
            [JsonProperty("children_array_ptr", Required = Required.Always)]
            public uint childrenArrayPtr;

            public World(string name, Area area, List<List<Partition>> partitions, uint areaPartitionXCount, uint areaPartitionYCount, bool fudgeCount, uint areaPartitionPtr, uint virtPartitionPtr, uint worldChildrenPtr, uint worldChildValue, uint worldLightsPtr, List<uint> children, uint dataPtr, uint childrenArrayPtr)
            {
                this.name = name;
                this.area = area;
                this.partitions = partitions;
                this.areaPartitionXCount = areaPartitionXCount;
                this.areaPartitionYCount = areaPartitionYCount;
                this.fudgeCount = fudgeCount;
                this.areaPartitionPtr = areaPartitionPtr;
                this.virtPartitionPtr = virtPartitionPtr;
                this.worldChildrenPtr = worldChildrenPtr;
                this.worldChildValue = worldChildValue;
                this.worldLightsPtr = worldLightsPtr;
                this.children = children;
                this.dataPtr = dataPtr;
                this.childrenArrayPtr = childrenArrayPtr;
            }

            [JsonConstructor]
            private World() { }
        }

        protected Node(object value, NodeType variant)
        {
            this.value = value;
            this.Variant = variant;
        }

        protected object value;
        public NodeType Variant { get; protected set; }
        public bool Is<T>() where T : class { return typeof(T).IsInstanceOfType(value); }
        public T As<T>() where T : class { return (T)value; }
        public object GetValue() { return value; }
    }

    [JsonConverter(typeof(DiscriminatedUnionConverter<ResolvedNode>))]
    public class ResolvedNode : Node<ResolvedNode>
    {
        public ResolvedNode(Camera camera) : base(camera, NodeType.Camera)
        {
        }

        public ResolvedNode(Display display) : base(display, NodeType.Display)
        {
        }

        public ResolvedNode(Empty empty) : base(empty, NodeType.Empty)
        {
        }

        public ResolvedNode(Light light) : base(light, NodeType.Light)
        {
        }

        public ResolvedNode(Lod lod) : base(lod, NodeType.Lod)
        {
        }

        public ResolvedNode(Object3d object3d) : base(object3d, NodeType.Object3d)
        {
        }

        public ResolvedNode(Window window) : base(window, NodeType.Window)
        {
        }

        public ResolvedNode(World world) : base(world, NodeType.World)
        {
        }
    }

    [JsonConverter(typeof(DiscriminatedUnionConverter<IndexedNode>))]
    public class IndexedNode : Node<uint>
    {
        public IndexedNode(Camera camera) : base(camera, NodeType.Camera)
        {
        }

        public IndexedNode(Display display) : base(display, NodeType.Display)
        {
        }

        public IndexedNode(Empty empty) : base(empty, NodeType.Empty)
        {
        }

        public IndexedNode(Light light) : base(light, NodeType.Light)
        {
        }

        public IndexedNode(Lod lod) : base(lod, NodeType.Lod)
        {
        }

        public IndexedNode(Object3d object3d) : base(object3d, NodeType.Object3d)
        {
        }

        public IndexedNode(Window window) : base(window, NodeType.Window)
        {
        }

        public IndexedNode(World world) : base(world, NodeType.World)
        {
        }
    }
}
