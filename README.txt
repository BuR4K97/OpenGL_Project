--------------------------------------------------------------------------------------
-------------------------------   OpenGL Application   -------------------------------
--------------------------------------------------------------------------------------

How to run: In the path "OpenGL_Project/OpenGL_Project/bin/Release", there is a shortcut for executable named "OpenGL_Project.exe".

How to compile: You may use OpenGL_Project.sln to open source files in Visual Studio. 
All dependencies like .dll files included along with runnable file, so it is enough to open .sln file to open C# code and compile it.

Source Code Files Explanation: There four subfolder named as "HelperTools", "Configurations", "Geometry" and "Graphics" to store source files.
	
	- HelperTools: Provides basic tools like fileHandler to use them in the development of other packages.

	- Configurations: Basically, some tools to set some specified configurations on app domain; not much related with graphic assignment.

	- Geometry: Defines some primitives like Vector and Coordinate, also some model classes like Polygon, Triangle, Quadrangle and GeometricObject.
	Using them to model the geometric data of objects for rendering purposes. 
	For such purpose, it contains graphics-useful structure like Tranformable and IObjectModel to throughput the data directly render purposed structures.
	
	- Graphics: Defines some primitives like Renderable and its extensions, Vertex and Camera; also some models for specified objects like Rock, Tree... 
	Also, it provides ShaderProgram to enable loading shaders into GPU properly. 
	It has OpenGLScene and OpenGLWindow to display rendered context through defined graphics-structures.

Geometry.Models:
	
	- Polygon: Most basic structure among this package. It defines polygonal properties like edge coordinates and normal vector.
	It provides some constant for validation for polygon instances and methods for data manipulation.
	
	- Triangle: Extension class of Polygon with specific constant for edge number and overrided methods using triangular properties.
	
	- Quadrangle: Same with triangle-polygon relation; a different extension class of Polygon with quadratic properties.

	- GeometricObject: A class for storing many Polygons once, that is, it may define geometric data of an particular part of objects.
	A GeometricObject can hold only one type of Polygon like only Triangular or Quadratic or Polygonal to determine stable geometric data.
	
	- IObjectModel: An interface to define general propert of an object model which matches a string id with a list of GeometricObject.
	It can keep many key and value match at once. 
	But each value(GeometricObject List) can be considered as one unite entity which rendered and transformed as one.

	- SingularObjectModel: Implementation of IObjectModel with only one key and one value. Keeps one entity (GeometricObject List).
	Provides data manipulation and transfer methods. Also, SingularObjectModel can containsone type of GeometricObject in terms of Polygonal, Triangular and Quadratic.

	- Tranformable: Defines geometric transformation properties like Translation, Rotation, Scaling and matrix operations for them.
	Provides mechanisms for generating output transformation of applying a new transformation over a existing transformation.
	Also, it includes an event-driven system for transferring applied transformations to delegate handlers.

	- TransformableObject: Extension of Transformable Class along with an IObjectModel instance to combine Transformable properties with an object model.
	That is, it defines both object model and transformable characteristics at once.

Graphics.Primitives:

	- Vertex: Defines vertex properties like Coordinate, Color and Normal Vector.
	Provides a mechanism for combinining many normal vector into one for the case that a vertex can be involved in many polygons.

	- VertexData: Basically, provides data extraction from Vertex in proper format to buffer.

	- Renderable: Main class for allocating GPU memory by creating vertexArray, arrayBuffer and elementBuffer. Implemented proper deallaction of resources too.
	Using the idea of rendering through indices which buffered through GL_ELEMENT_BUFFER.
	It can apply drawing only in GL_TRIANGLES and GL_QUADS. Because, GL_POLYGONS does not comply with drawing SingularObjectModel with one Renderable.
	It keeps VertexData List for vertices and uint List for indices.
	It contains model matrix to apply model transformation.

	- RenderableIdentity: Provides mechanisms for transferring geometric data of SingularObjectModel (GeometricObject List) into Renderable form.
	Extension of Renderable Class to initialize vertices and indices properties of Renderable with a SingularObjectModel.
	Applies proper normal vector calculations for a Vertex.
	
	- RenderableObject: Designed to store many RenderableIdentites and matches them with string ids. 
	That is, it is graphic modelling for TransformableObject which may contain many entities (GeometricObjectList) with different transformation for each.
	Initialiazes RenderableIdentity with a TransformableObject to transfer geometric data. 
	Also, event handling process of TransformableObject is implemented here to transfer new transformation directly model matrix property of RenderableIdentity.
	
	- Camera: Defines camera attributes like FOV, AspectRatio and near, far planes to determine projection matrix.
	Extends Transformable to implement view transformation properties.
	Uses event driven model to transfer changes directly to GL uniform variables through delegate handlers.

Graphics.Shaders:
	
	- ShaderProgram: Handles the assembly of shader programs into GPU. 
	Extracts source data from shader files, creates and compiles shaders and link them in a created program.
	Stores the address location of vertex attributes and uniform variables in created program.

Graphics.config:

	- GLConfig: Keeps the global variables related with GL, that is, active shader programs and its corresponding attribute and uniform location.
	Initializes GL with specific config.
	Renderable instances uses GLConfig to extract location of gl variables to use them in gl methods.

Graphics.Models:

	- ObjectMeshLoader: Sophisticated Object mesh loading class for .obj file format and used to load mesh data of objects.

	- ColorPackage: Designed with the purpose to match Coordinate instances with its colors. 
	Since, geometric data constructed and used with Geometry class which contains no color data.

Graphics:
	
	- OpenGLScene: Holds renderable objects to render them along with a Camera.
	Camera event handlers are implemented here.	 