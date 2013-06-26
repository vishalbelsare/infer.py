#-----------------------------------------------------------------------------------
# Infer.NET IronPython example: Bayes Point Machine with 2 features
#-----------------------------------------------------------------------------------

import InferNetWrapper
from InferNetWrapper import *
from MicrosoftResearch.Infer.Distributions import VectorGaussian
from MicrosoftResearch.Infer.Distributions import Distribution

def bayes_point_machine():
    print("\n\n------------------ Infer.NET Bayes Point Machine example ------------------\n");
    # The model
    len = Variable.New[int]()
    j = Range(len)
    x = Variable.Array[Vector](j)
    y = Variable.Array[bool](j)
    w0 = VectorGaussian(Vector.Zero(3), PositiveDefiniteMatrix.Identity(3))
    w = Variable.Random[Vector](w0)
    noise = 0.1
    tmp = Variable.GaussianFromMeanAndVariance(
        Variable.InnerProduct(w,
                              x.get_Item(j)).Named("innerProduct"),
        noise)

    y.set_Item(j, tmp.op_GreaterThan(tmp, 0))

    # The data
    incomes = System.Array[float]((63, 16, 28, 55, 22, 20 ))
    ages = System.Array[float]((38, 23, 40, 27, 18, 40 ))
    willBuy = System.Array[bool]((True, False, True, True, False, False))
    dataLen = willBuy.Length
    xdata = System.Array.CreateInstance(Vector, dataLen)
    for i in range(0, dataLen):
        xdata[i] = Vector.FromArray(System.Array[float]((incomes[i], ages[i], 1.0)))

    # Binding the data
    x.ObservedValue = xdata
    y.ObservedValue = willBuy
    len.ObservedValue = dataLen

    # Inferring the weights
    ie = InferenceEngine()
    wPosterior = ie.Infer[VectorGaussian](w)
    print "Dist over w=\n", wPosterior

    # Prediction
    incomesTest = System.Array[float]((58, 18, 22))
    agesTest = System.Array[float]((36, 24, 37))
    testDataLen = incomesTest.Length
    xtestData = System.Array.CreateInstance(Vector, testDataLen)
    for i in range(0, testDataLen):
        xtestData[i] = Vector.FromArray(System.Array[float]((incomesTest[i],
                                                             agesTest[i], 1.0)))

    jtest = Range(testDataLen)
    xtest = Variable.Array[Vector](jtest)
    xtest.ObservedValue = xtestData

    wtest = Variable.Random[Vector](wPosterior)
    ytest = Variable.Array[bool](jtest)
    tmp2 = Variable.GaussianFromMeanAndVariance(
        Variable.InnerProduct(wtest, xtest.get_Item(jtest)), noise)
    ytest.set_Item(jtest, tmp2.op_GreaterThan(tmp2, 0))
    ypred = Distribution.ToArray[System.Array[Bernoulli]](ie.Infer(ytest))
    print "Output = ", ypred[0], ",", ypred[1], ",", ypred[2]
