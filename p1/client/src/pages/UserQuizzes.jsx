import QuizzesTable from "../components/QuizzesTable";

const UserQuizzes = () => {
  return (
    <div className="bg-neutral-content max-w-full h-screen">
      <h1 className="text-center font-mono text-5xl font-bold pt-16 pb-12 text-neutral">
        User Quizzes
      </h1>
      <div className="py-16 mx-24 border border-zinc-200 bg-zinc-500 rounded-lg shadow-xl">
        <QuizzesTable />
      </div>
    </div>
  );
};

export default UserQuizzes;
