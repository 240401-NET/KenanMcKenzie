import backgroundImage from "../assets/greenindexcard.jpg";
const Landing = () => {
  return (
    <div
      className="hero min-h-screen"
      style={{
        backgroundImage: `url(${backgroundImage})`,
      }}
    >
      <div className="hero-overlay bg-opacity-40"></div>
      <div className="hero-content text-center text-neutral-content">
        <div className="max-w-lg">
          <h1 className="mb-8 text-5xl font-bold">Welcome to Quiz App</h1>
          <p className="mb-8 text-xl font-semibold">
            Create quizzes and get prepared for exams and qc&apos;s
          </p>
          <button className="btn bg-zinc-600 text-amber-400 border-amber-400 w-48 text-lg hover:bg-amber-400 hover:text-zinc-600 hover:scale-110 hover:border-zinc-600">
            Get Started
          </button>
        </div>
      </div>
    </div>
  );
};

export default Landing;
