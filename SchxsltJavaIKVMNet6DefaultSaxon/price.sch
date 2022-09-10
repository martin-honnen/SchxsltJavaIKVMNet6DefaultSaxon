<?xml version="1.0" encoding="UTF-8"?>
<schema xmlns="http://purl.oclc.org/dsdl/schematron" queryBinding="xslt3">
    <pattern>
        <rule context="book">
            <assert test="@price > 10">The book price is too small</assert>
            <report test="@price > 1000">The book price is too big</report>
        </rule>
    </pattern>
</schema>
