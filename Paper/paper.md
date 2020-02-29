---
title: 'PlagiarismChecker: Automated Plagiarism Detection in Academic Writing'
tags:
  - C#
  - WPF
  - Plagiarism
authors:
  - name: Atish Kumar Dipongkor
    orcid: 0000-0001-8253-429X
    affiliation: 1
affiliations:
 - name: Jashore University of Science and Technology
   index: 1
date: 23 January 2020
bibliography: paper.bib

---
# Statement of Need

Operating in space necessitates quantifying the positions, velocities, geometries, and other properties of spacecraft and planetary
 bodies through time. 
Scientists and engineers working with robotic planetary spacecraft missions use the Spacecraft, Planet, Instrument, Camera-matrix, Events
 (SPICE) Toolkit [@acton:2018] to help plan observations and to quantify the positions of planetary bodies and spacecraft through time. 
SPICE is developed at the Jet Propulsion Laboratory by NASA's Navigation and Ancillary Information Facility (NAIF). Scientists also use
 SPICE to analyze data returned by these missions and to plan hypothetical orbital trajectories for future missions [@acton:2018]. 
For example, SPICE can calculate future occultations of planets relative to a camera on a rover or spacecraft. 
The NAIF provides SPICE in Fortran 77, C, and they also provide Matlab and IDL wrappers; however, as of 2014, they did not offer a Python
 interface. 
The growth of Python and movement away from proprietary interpreted languages [@burrell:2018] motivated the development of SpiceyPy so
 that planetary scientists and engineers can use SPICE within Python. 

# Summary

``SpiceyPy`` is an open-source, MIT licensed Python package that provides a ``pythonic`` interface to nearly all of the C SPICE toolkit N66. 
``SpiceyPy`` was developed in Python using the ``ctypes`` module of the CPython standard library to wrap the underlying C SPICE shared library. 
Developing ``SpiceyPy`` in Python enabled the SpiceyPy API to expose simplified and more ``pythonic`` interactions with the underlying C API for SPICE.
``SpiceyPy`` relies on the NumPy library for numeric arrays and tight integration with the SciPy stack.

``SpiceyPy`` is extensively tested using a combination of unit and integration tests, which run using continuous integration services. 
The tests also serve as code examples translated from the NAIF documentation. 
Continuous deployment updates documentation and deploys artifacts of releases to PyPI and the conda-forge. 
Every SPICE function wrapper in SpiceyPy contains docstrings that provide short descriptions of the function duplicated from the SPICE
 documentation. 
Docstrings in SpiceyPy also contain links to the corresponding CSPICE documentation page hosted by the NAIF to provide additional details
 regarding the function. 

``SpiceyPy`` enables scientists to utilize the full functionality of SPICE within Python and the ecosystem of visualization and
 scientific packages available. 
``SpiceyPy`` has been utilized in peer-reviewed research [@behar:2016; @behar:2017; @porter:2018; @zangari:2018; @attree:2019], masters
 and doctoral theses [@hackett:2019; @albin:2019], spacecraft mission operations, as a dependency in other Python libraries [@heliopy:2019
 ], and for a variety of other projects [@wilson:2016; @wilson_times:2017; @costa:2018]. 

# Acknowledgements
The authors would like to acknowledge members of the NAIF (Charles Acton, Ed Wright, Boris Semenov, Nat Bachman) for continued support for
 SpiceyPy and for providing to users a *SpiceyPy translation* of their excellent "Hands-on" lessons. 
The first author also thanks all of the contributors and users of SpiceyPy; they motivate further improvements to the project. 
Co-authors other than the first author are ordered solely alphabetically by their first name. 

# References