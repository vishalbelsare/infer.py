using System;
using MicrosoftResearch.Infer;
using MicrosoftResearch.Infer.Distributions;
using MicrosoftResearch.Infer.Collections;
using MicrosoftResearch.Infer.Factors;

namespace MicrosoftResearch.Infer.Models.User
{
	/// <summary>
	/// Generated algorithm for performing inference
	/// </summary>
	/// <remarks>
	/// The easiest way to use this class is to wrap an instance in a CompiledAlgorithm object and use
	/// the methods on CompiledAlgorithm to set parameters and execute inference.
	/// 
	/// If you instead wish to use this class directly, you must perform the following steps:
	/// 1) Create an instance of the class
	/// 2) Set the value of any externally-set fields e.g. data, priors
	/// 3) Call the Execute(numberOfIterations) method
	/// 4) Use the XXXMarginal() methods to retrieve posterior marginals for different variables.
	/// 
	/// Generated by Infer.NET 2.5 at 8:23 AM on Thursday, May 02, 2013.
	/// </remarks>
	public partial class Model_EP : IGeneratedAlgorithm
	{
		#region Fields
		/// <summary>Field backing the NumberOfIterationsDone property</summary>
		private int numberOfIterationsDone;
		/// <summary>The number of iterations last computed by Constant. Set this to zero to force re-execution of Constant</summary>
		public int Constant_iterationsDone;
		/// <summary>Message to marginal of 'vbool0'</summary>
		public Bernoulli vbool0_marginal_F;
		/// <summary>Message to marginal of 'vbool1'</summary>
		public Bernoulli vbool1_marginal_F;
		/// <summary>Message to marginal of 'vbool2'</summary>
		public Bernoulli vbool2_marginal_F;
		#endregion

		#region Properties
		/// <summary>The number of iterations done from the initial state</summary>
		public int NumberOfIterationsDone
		{			get {
				return this.numberOfIterationsDone;
			}
		}

		#endregion

		#region Methods
		/// <summary>Get the observed value of the specified variable.</summary>
		/// <param name="variableName">Variable name</param>
		public object GetObservedValue(string variableName)
		{
			throw new ArgumentException("Not an observed variable name: "+variableName);
		}

		/// <summary>Set the observed value of the specified variable.</summary>
		/// <param name="variableName">Variable name</param>
		/// <param name="value">Observed value</param>
		public void SetObservedValue(string variableName, object value)
		{
			throw new ArgumentException("Not an observed variable name: "+variableName);
		}

		/// <summary>The marginal distribution of the specified variable.</summary>
		/// <param name="variableName">Variable name</param>
		public object Marginal(string variableName)
		{
			if (variableName=="vbool0") {
				return this.Vbool0Marginal();
			}
			if (variableName=="vbool1") {
				return this.Vbool1Marginal();
			}
			if (variableName=="vbool2") {
				return this.Vbool2Marginal();
			}
			throw new ArgumentException("This class was not built to infer "+variableName);
		}

		public T Marginal<T>(string variableName)
		{
			return Distribution.ChangeType<T>(this.Marginal(variableName));
		}

		/// <summary>The query-specific marginal distribution of the specified variable.</summary>
		/// <param name="variableName">Variable name</param>
		/// <param name="query">QueryType name. For example, GibbsSampling answers 'Marginal', 'Samples', and 'Conditionals' queries</param>
		public object Marginal(string variableName, string query)
		{
			if (query=="Marginal") {
				return this.Marginal(variableName);
			}
			throw new ArgumentException(((("This class was not built to infer \'"+variableName)+"\' with query \'")+query)+"\'");
		}

		public T Marginal<T>(string variableName, string query)
		{
			return Distribution.ChangeType<T>(this.Marginal(variableName, query));
		}

		/// <summary>The output message of the specified variable.</summary>
		/// <param name="variableName">Variable name</param>
		public object GetOutputMessage(string variableName)
		{
			throw new ArgumentException("This class was not built to compute an output message for "+variableName);
		}

		/// <summary>Update all marginals, by iterating message passing the given number of times</summary>
		/// <param name="numberOfIterations">The number of times to iterate each loop</param>
		/// <param name="initialise">If true, messages that initialise loops are reset when observed values change</param>
		private void Execute(int numberOfIterations, bool initialise)
		{
			this.Constant();
			this.numberOfIterationsDone = numberOfIterations;
		}

		public void Execute(int numberOfIterations)
		{
			this.Execute(numberOfIterations, true);
		}

		public void Update(int additionalIterations)
		{
			this.Execute(this.numberOfIterationsDone+additionalIterations, false);
		}

		private void OnProgressChanged(ProgressChangedEventArgs e)
		{
			// Make a temporary copy of the event to avoid a race condition
			// if the last subscriber unsubscribes immediately after the null check and before the event is raised.
			EventHandler<ProgressChangedEventArgs> handler = this.ProgressChanged;
			if (handler!=null) {
				handler(this, e);
			}
		}

		/// <summary>Reset all messages to their initial values.  Sets NumberOfIterationsDone to 0.</summary>
		public void Reset()
		{
			this.Execute(0);
		}

		/// <summary>Computations that do not depend on observed values</summary>
		public void Constant()
		{
			if (this.Constant_iterationsDone==1) {
				return ;
			}
			// The constant 'vBernoulli0'
			Bernoulli vBernoulli0 = Bernoulli.FromLogOdds(0);
			this.vbool0_marginal_F = ArrayHelper.MakeUniform<Bernoulli>(vBernoulli0);
			// Message from use of 'vbool0'
			Bernoulli vbool0_use_B = ArrayHelper.MakeUniform<Bernoulli>(vBernoulli0);
			// Message to 'vbool0_marginal' from Variable factor
			this.vbool0_marginal_F = VariableOp.MarginalAverageConditional<Bernoulli>(vbool0_use_B, vBernoulli0, this.vbool0_marginal_F);
			this.vbool1_marginal_F = ArrayHelper.MakeUniform<Bernoulli>(vBernoulli0);
			// Message from use of 'vbool1'
			Bernoulli vbool1_use_B = ArrayHelper.MakeUniform<Bernoulli>(vBernoulli0);
			// Message to 'vbool1_marginal' from Variable factor
			this.vbool1_marginal_F = VariableOp.MarginalAverageConditional<Bernoulli>(vbool1_use_B, vBernoulli0, this.vbool1_marginal_F);
			Bernoulli vbool2_F = ArrayHelper.MakeUniform<Bernoulli>(new Bernoulli());
			this.vbool2_marginal_F = ArrayHelper.MakeUniform<Bernoulli>(new Bernoulli());
			// Message from use of 'vbool2'
			Bernoulli vbool2_use_B = ArrayHelper.MakeUniform<Bernoulli>(new Bernoulli());
			// Message to 'vbool2' from And factor
			vbool2_F = BooleanAndOp.AndAverageConditional(vBernoulli0, vBernoulli0);
			// Message to 'vbool2_marginal' from DerivedVariable factor
			this.vbool2_marginal_F = DerivedVariableOp.MarginalAverageConditional<Bernoulli>(vbool2_use_B, vbool2_F, this.vbool2_marginal_F);
			this.Constant_iterationsDone = 1;
		}

		/// <summary>
		/// Returns the marginal distribution for 'vbool0' given by the current state of the
		/// message passing algorithm.
		/// </summary>
		/// <returns>The marginal distribution</returns>
		public Bernoulli Vbool0Marginal()
		{
			return this.vbool0_marginal_F;
		}

		/// <summary>
		/// Returns the marginal distribution for 'vbool1' given by the current state of the
		/// message passing algorithm.
		/// </summary>
		/// <returns>The marginal distribution</returns>
		public Bernoulli Vbool1Marginal()
		{
			return this.vbool1_marginal_F;
		}

		/// <summary>
		/// Returns the marginal distribution for 'vbool2' given by the current state of the
		/// message passing algorithm.
		/// </summary>
		/// <returns>The marginal distribution</returns>
		public Bernoulli Vbool2Marginal()
		{
			return this.vbool2_marginal_F;
		}

		#endregion

		#region Events
		/// <summary>Event that is fired when the progress of inference changes, typically at the end of one iteration of the inference algorithm.</summary>
		public event EventHandler<ProgressChangedEventArgs> ProgressChanged;
		#endregion

	}

}
